using System.Collections;
using UnityEngine;
using Utilities;
using Random = UnityEngine.Random;

namespace Shmup
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] Item[] itemPrefabs;
        [SerializeField] float spawnInterval = 3f;
        [SerializeField] float spawnRadius = 3f;

        private Coroutine spawnCoroutine;

        void Start() => spawnCoroutine = StartCoroutine(SpawnItems());

        void OnDestroy()
        {
            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
            }
        }

        IEnumerator SpawnItems()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnInterval);
                var item = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)]);

                // Use Random.insideUnitCircle for 2D spawning
                Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
                item.transform.position = new Vector3(transform.position.x + randomPosition.x, transform.position.y + randomPosition.y, 0f);
            }
        }
    }
}
