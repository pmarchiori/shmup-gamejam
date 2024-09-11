using UnityEngine;

namespace Shmup
{
    public class Projectile : MonoBehaviour
    {
        public GameObject shooter;
        [SerializeField] float speed;
        [SerializeField] string damageTag;
        public void SetSpeed(float speed) => this.speed = speed;
        public void SetParent(Transform parent) => this.transform.SetParent(parent);

        public void SetDamageTag(string tag) => damageTag = tag;

        void Update()
        {
            transform.position += transform.up * (speed * Time.deltaTime);
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject == shooter)
            {
                Debug.Log($"Projétil ({name}) colidiu com o próprio atirador: {shooter.name}");
                return;
            }

            if (collider.CompareTag(damageTag))
            {
                Debug.Log($"Colisão detectada com: {collider.gameObject.name}");

                var ship = collider.gameObject.GetComponent<Ship>();
                if (ship != null)
                {
                    ship.TakeDamage(10);
                }

                Destroy(gameObject);
            }
        }
    }
}
