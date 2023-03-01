using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerManager : MonoBehaviour
{
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

        Instantiate(randomGameObject, randomSpawn, Quaternion.identity * Quaternion.Euler(0,180,0));
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            SpawnRandomObject();
            yield return new WaitForSeconds(Random.Range(1, 3));
        }
    }
}
