using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shmup
{
    public class Boss : MonoBehaviour
    {
        [SerializeField] float maxHealth = 100f;
        float health;

        Collider2D bossCollider;

        public List<BossStage> Stages;
        int currentStage = 0;

        public event Action OnHealthChanged;

        void Awake() => bossCollider = GetComponent<Collider2D>();

        void Start()
        {
            health = maxHealth;
            bossCollider.enabled = true; // Mantém o colisor habilitado ao iniciar

            foreach (var system in Stages.SelectMany(stage => stage.enemySystems))
            {
                system.OnSystemDestroyed.AddListener(CheckStageComplete);
            }

            // Desabilita invulnerabilidade para o primeiro estágio se necessário
            if (Stages[currentStage].IsBossInvulnerable)
            {
                Stages[currentStage].IsBossInvulnerable = false; // Permite dano no início
            }

            InitializeStage();
        }


        public float GetHealthNormalized() => health / maxHealth;

        void CheckStageComplete()
        {
            if (Stages[currentStage].IsStageComplete())
            {
                AdvanceToNextStage();
            }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            health -= 10; // Subtrai o dano

            OnHealthChanged?.Invoke(); // Notifica a mudança de vida

            if (health <= maxHealth * 0.5f && currentStage == 0) // Verifica se a vida está abaixo de 50% e se ainda está no primeiro estágio
            {
                EndStage(); // Finaliza o primeiro estágio
                AdvanceToNextStage(); // Avança para o segundo estágio
            }

            if (health <= 0)
            {
                BossDefeated(); // Derrota o boss se a vida chegar a 0
            }
        }

        void AdvanceToNextStage()
        {
            EndStage(); // Finaliza o estágio atual

            currentStage++; // Avança para o próximo estágio

            if (currentStage < Stages.Count)
            {
                InitializeStage(); // Inicializa o próximo estágio

                // Certifique-se de que o boss não está invulnerável no novo estágio
                if (Stages[currentStage].IsBossInvulnerable)
                {
                    Stages[currentStage].IsBossInvulnerable = false;
                }

                bossCollider.enabled = true; // Garante que o colisor esteja ativo
                Debug.Log($"Avançou para o estágio {currentStage + 1}");
            }
        }

        void InitializeStage()
        {
            Stages[currentStage].InitializeStage(); // Inicializa os sistemas do estágio atual

            // Garante que o boss esteja vulnerável, a menos que o estágio exija invulnerabilidade
            bossCollider.enabled = !Stages[currentStage].IsBossInvulnerable;

            Debug.Log($"Iniciando o estágio {currentStage + 1}, invulnerável: {Stages[currentStage].IsBossInvulnerable}");
        }


        void EndStage()
        {
            Stages[currentStage].EndStage(); // Finaliza o estágio atual
            bossCollider.enabled = false; // Desativa o colisor temporariamente enquanto a transição ocorre, se necessário
        }

        void BossDefeated()
        {
            Debug.Log("Boss defeated!");
        }
    }
}