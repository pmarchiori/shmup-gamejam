using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shmup
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameObject gameOverUI;
        [SerializeField] GameObject gameWonUI;
        [SerializeField] GameObject bossPrefab;

        public static GameManager Instance { get; private set; }
        public Player Player => player;
        public GameObject ShopMenu;

        Player player;
        Boss boss;
        public EnemySpawner enemySpawner;
        int score;
        float restartTimer = 3f;
        public float timePerLevel;
        float levelTimer;
        int levelCount;
        public int bossSpawn = 2; // O boss aparece no levelCount 2
        public float spawnRamp;
        public bool bossAlive;


        public bool IsGameOver()
        {
            return player.GetHealthNormalized() <= 0;
        }

        public bool IsGameWon()
        {
            if (bossPrefab.activeInHierarchy)
            {
                bossAlive = boss.GetHealthNormalized() <= 0;
            }
            return bossAlive;
        }

        void Awake()
        {
            Instance = this;
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            levelTimer = timePerLevel;
            levelCount = 0;
        }

        void Update()
        {
            // Verificação de Game Over
            if (IsGameOver())
            {
                restartTimer -= Time.deltaTime;

                if (!gameOverUI.activeSelf)
                {
                    gameOverUI.SetActive(true);

                }

                if (restartTimer <= 0)
                {
                    SceneManager.LoadScene(0);
                }
            }

            // Verificação de vitória
            if (IsGameWon())
            {
                restartTimer -= Time.deltaTime;

                if (!gameWonUI.activeSelf)
                {
                    gameWonUI.SetActive(true);
                }

                if (restartTimer <= 0)
                {
                    SceneManager.LoadScene(0);
                }
            }

            // Controle do temporizador de nível
            levelTimer -= Time.deltaTime;

            if (levelTimer <= 0 && !IsGameOver() && !IsGameWon())
            {
                levelTimer = timePerLevel;
                //Time.timeScale = 0f;
                //ShopMenu.SetActive(true);
                levelCount++;
                if (levelCount >= bossSpawn)
                {
                    enemySpawner.spawnInterval /= spawnRamp;
                }

            }

            // Ativação do Boss no levelCount 2
            if (levelCount == bossSpawn && !bossPrefab.activeInHierarchy)
            {
                bossPrefab.SetActive(true);  // Ativa o bossPrefab
                boss = bossPrefab.GetComponent<Boss>();  // Pega a referência do Boss
            }
        }

        public void AddScore(int amount) => score += amount;
        public int GetScore() => score;
    }
}
