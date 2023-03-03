using System.Collections;
using UnityEngine;

public class ObjectSpawnerManager : MonoBehaviour
{
    [SerializeField]
    float _spawnStartDelay = 3f;
    [SerializeField]
    Transform[] _spawnPoints;
    [SerializeField]
    GameObject[] _objects;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    void SpawnRandomObject()
    {
        GameObject randomGameObject = _objects[Random.Range(0, _objects.Length)];
        Vector3 randomSpawn = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;

        Instantiate(randomGameObject, randomSpawn, Quaternion.identity * Quaternion.Euler(0, 180, 0));
    }

    IEnumerator SpawnObject()
    {
        /*yield return new WaitForSeconds(_spawnStartDelay);

        while (GameManager.instance.isGameOver == false)
        {
            SpawnRandomObject();
            yield return new WaitForSeconds(Random.Range(1, 3));
        }*/

        float spawnDelay = _spawnStartDelay;
        float shortPauseDuration = 1f;

        yield return new WaitForSeconds(spawnDelay);

        while (GameManager.instance.isGameOver == false)
        {
            SpawnRandomObject();

            // Reduce the delay between spawns by a small amount
            spawnDelay = Mathf.Max(0.35f, spawnDelay - 0.1f);

            // Wait for the new spawn delay before spawning the next object
            yield return new WaitForSeconds(spawnDelay);

            // Reduce the short pause duration by a small amount
            shortPauseDuration = Mathf.Max(0.35f, shortPauseDuration - 0.05f);

            // Pause for a short duration before starting the next wave of objects
            yield return new WaitForSeconds(shortPauseDuration);
        }
    }
}
