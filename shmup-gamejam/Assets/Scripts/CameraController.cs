using UnityEngine;

namespace Shmup
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Transform player;
        [SerializeField] float speed = 2f;

        void Start() => transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

        void LateUpdate()
        {
            // move the camera along the scenario at a constant speed
            transform.position += Vector3.up * (speed * Time.deltaTime);
        }
    }
}