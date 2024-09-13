using UnityEngine;

namespace Shmup
{
    public class Player : Ship
    {
        protected override void Die()
        {
            Debug.Log("Player dead");
            Destroy(gameObject);
        }
    }
}