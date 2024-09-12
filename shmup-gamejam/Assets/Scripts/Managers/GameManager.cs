using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shmup
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameObject gameOverUI;

        public static GameManager Instance { get; private set; }
        public Player Player => player;

        Player player;
        Boss boss;
        int score;
        float restartTimer = 3f;

        public bool IsGameOver() => player.GetHealthNormalized() <= 0 || boss.GetHealthNormalized() <= 0;

        void Awake()
        {
            Instance = this;
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
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
        }

        public void AddScore(int amount) => score += amount;
        public int GetScore() => score;
    }
}