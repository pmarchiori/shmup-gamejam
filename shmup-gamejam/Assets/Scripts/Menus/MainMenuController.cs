using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shmup
{
    public class MainMenuController : MonoBehaviour
    {
        public void StartGame ()
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }

        public void ExitGame ()
        {
            Debug.Log("Game Closed");
            Application.Quit();
        }
    }
}
