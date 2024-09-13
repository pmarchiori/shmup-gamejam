using UnityEngine;

namespace Shmup
{
    public class HealthItem : Item
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            // Tenta obter o componente Player no objeto que colidiu
            Player player = other.GetComponent<Player>();

            // Verifica se o Player não é null
            if (player != null)
            {
                player.AddHealth((int)amount);
                Destroy(gameObject);
            }
        }
    }
}
