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
            transform.position += Vector3.down * (speed * Time.deltaTime); //move the camera up at a constant speed
        }
    }
}