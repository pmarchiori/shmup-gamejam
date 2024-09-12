using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shmup
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameObject gameOverUI;

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
        public int bossSpawn;
        public float spawnRamp;
        

        public bool IsGameOver() => player.GetHealthNormalized() <= 0 || boss.GetHealthNormalized() <= 0;

        void Awake()
        {
            Instance = this;
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
            levelTimer = timePerLevel;
            levelCount = 0;
            bossSpawn = 0;
        }

        void Update()
        {
            if (IsGameOver())
            {
                restartTimer -= Time.deltaTime;

                if (gameOverUI.activeSelf == false)
                {
                    gameOverUI.SetActive(true);
                }

                if (restartTimer <= 0)
                {
                    SceneManager.LoadScene(0);
                }
            }
            
            levelTimer -= Time.deltaTime;
            
             if (levelTimer <= 0)
            {
                levelTimer = timePerLevel;
                Time.timeScale = 0f;
                ShopMenu.SetActive(true);
                levelCount++;
                enemySpawner.spawnInterval /= spawnRamp;
            }

             if (levelCount == bossSpawn)
            {

            }
        }

        public void AddScore(int amount) => score += amount;
        public int GetScore() => score;
    }
}