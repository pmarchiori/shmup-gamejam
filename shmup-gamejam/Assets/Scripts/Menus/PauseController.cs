using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shmup
{
    public class PauseController : MonoBehaviour
    {
        public GameObject PauseMenu;
        public static bool isPaused;

        void Start()
        {
            PauseMenu.SetActive(false);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }

        public void PauseGame()
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }

        public void ResumeGame()
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }

        public void GoToMainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }

        public void QuitGame()
        {
            Debug.Log("Game Closed");
            Application.Quit();
        }
    }
}
