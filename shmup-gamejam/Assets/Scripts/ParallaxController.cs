using UnityEngine;

namespace Shmup
{
    public class ParalaxController : MonoBehaviour
    {
        [SerializeField] Transform[] backgrounds; //array of background layers
        [SerializeField] float smoothing = 10f; //how smooth the parallax effect is
        [SerializeField] float multiplier = 15f; //how much the parallax effect increments per layer

        Transform mainCamera;
        Vector3 previousCamPosition; //position of the camera in the previous frame

        void Awake() => mainCamera = Camera.main.transform;

        void Start() => previousCamPosition = mainCamera.position;

        void Update()
        {
            //loop to iterate through each background layer
            for (var i = 0; i < backgrounds.Length; i++)
            {
                float parallax = (previousCamPosition.y - mainCamera.position.y) * (i * multiplier);
                float targetY = backgrounds[i].position.y + parallax;

                Vector3 targetPosition = new Vector3(backgrounds[i].position.x, targetY, backgrounds[i].position.z);

                backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, targetPosition, smoothing * Time.deltaTime);
            }

            previousCamPosition = mainCamera.position;
        }
    }

}