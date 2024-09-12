using UnityEngine;

namespace Shmup
{
    public class HealthItem : Item
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            other.GetComponent<Player>().AddHealth((int)amount);
            Destroy(gameObject);
        }
    }
}