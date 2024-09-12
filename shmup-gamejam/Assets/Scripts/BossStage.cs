using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shmup
{
    public class BossStage : MonoBehaviour
    {
        public List<EnemyShip> enemySystems;
        public bool IsBossInvulnerable = true;

        void Awake()
        {
            foreach (var system in enemySystems)
            {
                system.gameObject.SetActive(false);
            }
        }

        public void InitializeStage()
        {
            foreach (var system in enemySystems)
            {
                system.gameObject.SetActive(true);
            }
        }

        public bool IsStageComplete()
        {
            return enemySystems.All(system => system == null || !(system.GetHealthNormalized() > 0));
        }

        public void EndStage()
        {
            // Desativa os sistemas do estágio atual
            foreach (var system in enemySystems)
            {
                if (system != null)
                {
                    system.gameObject.SetActive(false); // Desativa cada sistema inimigo
                }
            }

            // Outras ações de finalização do estágio (opcional)
            Debug.Log("Estágio finalizado!");
        }
    }

}