using UnityEngine;

namespace Shmup
{
    public class PlayerWeapon : Weapon
    {
        private float fireTimer;
        //[SerializeField] private WeaponStrategy[] weaponStrategies; //array of weapon strategies for the player
        //private int currentStrategyIndex = 0;

        void Update()
        {
            fireTimer += Time.deltaTime;

            // //changes the player's weapon strategy when pressing space bar
            // if (Input.GetKeyDown(KeyCode.Space))
            // {
            //     currentStrategyIndex = (currentStrategyIndex + 1) % weaponStrategies.Length;
            //     SetWeaponStrategy(weaponStrategies[currentStrategyIndex]);
            // }

            if (fireTimer >= weaponStrategy.FireRate)
            {
                weaponStrategy.Fire(firePoint, layer);
                fireTimer = 0f;
            }
        }
    }
}
