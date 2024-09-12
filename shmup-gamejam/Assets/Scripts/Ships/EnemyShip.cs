using UnityEngine;
using UnityEngine.Events;

namespace Shmup
{
    public class EnemyShip : Ship
    {
        protected override void Die()
        {
            GameManager.Instance.AddScore(10);
            OnSystemDestroyed?.Invoke();
            Destroy(gameObject);
        }

        public UnityEvent OnSystemDestroyed;

    }
}