using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shmup
{
    public class shopController : MonoBehaviour
    {
        public GameObject ShopMenu;

        public void slot1()
        {
            exitShop();
        }

        public void slot2()
        {
            exitShop();
        }

        public void slot3()
        {
            exitShop();
        }

        public void exitShop()
        {
            Time.timeScale = 1.0f;
            ShopMenu.SetActive(false);
        }
    }
    
}
