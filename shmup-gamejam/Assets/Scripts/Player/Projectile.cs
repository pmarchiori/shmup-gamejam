using UnityEngine;
using System;

namespace Shmup
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float speed;
        // [SerializeField] GameObject shootingEffectPrefab;
        // [SerializeField] GameObject hitEffectPrefab;

        Transform parent;

        public void SetSpeed(float speed) => this.speed = speed;
        public void SetParent(Transform parent) => this.parent = parent;

        public Action Callback;


        private void Start()
        {
            //IMPLEMENTATION OF POSSIBLE EFFECT OR PARTICLE SYSTEM WHEN SHOOTING

            // if (shootingEffectPrefab != null)
            // {
            //     var muzzleVFX = Instantiate(shootingEffectPrefab, transform.position, Quaternion.identity);
            //     muzzleVFX.transform.forward = gameObject.transform.forward;
            //     muzzleVFX.transform.SetParent(parent);

            //     DestroyParticleSystem(muzzleVFX);

            // }
        }

        private void Update()
        {
            transform.SetParent(null);
            transform.position += transform.forward * (speed * Time.deltaTime);

            Callback?.Invoke();
        }


        private void OnCollisionEnter(Collision collision)
        {
            //IMPLEMENTATION OF POSSIBLE EFFECT OR PARTICLE SYSTEM WHEN PROJECTILE COLLIDES WITH TARGET

            // if (hitEffectPrefab != null)
            // {
            //     ContactPoint contact = collision.contacts[0];
            //     var hitVFX = Instantiate(hitEffectPrefab, contact.point, Quaternion.identity);

            //     DestroyParticleSystem(hitVFX);
            // }

            // var plane = collision.gameObject.GetComponent<Plane>();
            // if (plane != null)
            // {
            //     plane.TakeDamage(10);
            // }

            Destroy(gameObject); //destroy projectile
        }

        // private void DestroyParticleSystem(GameObject vfx)
        // {
        //     var ps = vfx.GetComponent<ParticleSystem>();
        //     if (ps == null)
        //     {
        //         ps = vfx.GetComponentInChildren<ParticleSystem>();
        //     }
        //     Destroy(vfx, ps.main.duration);
        // }
    }
}
