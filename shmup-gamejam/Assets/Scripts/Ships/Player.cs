using UnityEngine;

namespace Shmup
{
    public class Player : Ship
    {
        public Animator anim;

        protected override void Die()
        {
            Debug.Log("Player dead");
            anim.Play("player_death", 0, 0.25f);
            Destroy(gameObject);
        }
    }
}