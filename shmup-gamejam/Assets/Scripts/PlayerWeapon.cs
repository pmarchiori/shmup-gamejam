using UnityEngine;

namespace Shmup
{
    public class PlayerWeapon : Weapon
    {
        InputReader input;
        private float fireTimer;
        //[SerializeField] private WeaponStrategy[] weaponStrategies; //array of weapon strategies for the player
        //private int currentStrategyIndex = 0;

        void Awake() => input = GetComponent<InputReader>();

        void Update()
        {
            fireTimer += Time.deltaTime;

            // //changes the player's weapon strategy when pressing space bar
            // if (Input.GetKeyDown(KeyCode.Space))
            // {
            //     currentStrategyIndex = (currentStrategyIndex + 1) % weaponStrategies.Length;
            //     SetWeaponStrategy(weaponStrategies[currentStrategyIndex]);
            // }

            if (/*input.Fire && */fireTimer >= weaponStrategy.FireRate)
            {
                weaponStrategy.Fire(firePoint, layer);
                fireTimer = 0f;
            }
        }
    }
}
