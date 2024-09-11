using UnityEngine;

namespace Shmup
{
    [CreateAssetMenu(fileName = "SingleShot", menuName = "Shmup/WeaponStrategy/SingleShot")]
    public class SingleShot : WeaponStrategy
    {
        public override void Fire(Transform firePoint, LayerMask layer)
        {
            var projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            //projectile.transform.SetParent(firePoint);
            projectile.layer = layer;

            var projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.SetSpeed(projectileSpeed);
            projectileComponent.shooter = firePoint.parent.gameObject;
            projectileComponent.SetDamageTag(firePoint.CompareTag("Player") ? "Enemy" : "Player");

            Destroy(projectile, projectileLifetime);
        }

    }
}