using UnityEngine;

namespace Shmup
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] float smoothness = 0.1f;
        [SerializeField] GameObject model;

        [Header("Camera Bounds")]
        [SerializeField]
        Transform cameraFollow;

        [SerializeField] float minX;
        [SerializeField] float maxX;
        [SerializeField] float minY;
        [SerializeField] float maxY;

        InputReader input;

        Vector3 currentVelocity;
        Vector3 targetPosition;

        void Start()
        {
            input = GetComponent<InputReader>();
        }

        void Update()
        {
            targetPosition += new Vector3(input.Move.x, input.Move.y, 0f) * (speed * Time.deltaTime);

            // calculate the min and max X and Y positions for the player based on the camera view
            var minPlayerX = cameraFollow.position.x + minX;
            var maxPlayerX = cameraFollow.position.x + maxX;
            var minPlayerY = cameraFollow.position.y + minY;
            var maxPlayerY = cameraFollow.position.y + maxY;

            // clamp the player's position to the camera view
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPlayerX, maxPlayerX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPlayerY, maxPlayerY);

            // lerp the player's position to the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothness);
        }
    }
}