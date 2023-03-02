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
        yield return new WaitForSeconds(_spawnStartDelay);

        while (GameManager.instance.isGameOver == false)
        {
            SpawnRandomObject();
            yield return new WaitForSeconds(Random.Range(1, 3));
        }
    }
}
