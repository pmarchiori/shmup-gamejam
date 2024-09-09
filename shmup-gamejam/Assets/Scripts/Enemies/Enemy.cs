using UnityEngine;

namespace Shmup
{
    //mark a ScriptableObject-derived type to be automatically listed in the Assets/Create submenu, 
    //so that instances of the type can be easily created and stored in the project as ".asset" files.
    [CreateAssetMenu(fileName = "Enemy", menuName = "Shmup/Enemy", order = 0)]

    public class Enemy : ScriptableObject
    {
        public GameObject enemyPrefab;
        public GameObject weaponPrefab;
        public float enemySpeed;
    }
}