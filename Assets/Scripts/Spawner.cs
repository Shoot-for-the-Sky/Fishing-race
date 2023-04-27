using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Mover prefabToSpawn;
    [SerializeField] Vector3 velocityOfSpawnedObject;
    [Tooltip("Min time for spawn")][SerializeField] float minTime = 1f;
    [Tooltip("Max time for spawn")][SerializeField] float maxTime = 4f;
    [Tooltip("Max y dist")][SerializeField] float maxYDistance = 0.5f;

    void Start()
    {
        this.StartCoroutine(SpawnRoutine());

    }

    IEnumerator SpawnRoutine()
    {

        while (true)
        {
            float spawnInterval = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(spawnInterval);       // co-routines

            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x ,
                transform.position.y + Random.Range(-maxYDistance, +maxYDistance),
                transform.position.z);
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);
            newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
        }
    }
}