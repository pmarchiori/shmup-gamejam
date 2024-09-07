using UnityEngine;

namespace Shmup
{
    public class PlayerController : MonoBehaviour
    {
        private InputReader input;

        [Header("Player Configs")]
        [SerializeField] float speed;
        [SerializeField] float smoothness = 0.1f;


        [Header("Camera Configs")]
        [SerializeField] Transform mainCamera;
        [SerializeField] float minX; //max pos for the player on the downside of the screen
        [SerializeField] float maxX; //max pos for the player on the upside of the screen
        [SerializeField] float minY; //max pos for the player on the left side of the screen
        [SerializeField] float maxY; //max pos for the player on the right side of the screen

        Vector3 currentVelocity;
        Vector3 targetPosition;

        void Start() => input = GetComponent<InputReader>();

        void Update()
        {
            targetPosition += new Vector3(input.Move.x, input.Move.y, 0f) * (speed * Time.deltaTime);

            //calculate the max positions for the player to move based on the camera view
            float minPlayerX = mainCamera.position.x + minX;
            float maxPlayerX = mainCamera.position.x + maxX;
            float minPlayerY = mainCamera.position.y + minY;
            float maxPlayerY = mainCamera.position.y + maxY;

            //clamp the player's position to the camera view
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPlayerX, maxPlayerX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPlayerY, maxPlayerY);

            //lerp the player's position to the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothness);
        }
    }
}