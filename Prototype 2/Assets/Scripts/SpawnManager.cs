using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float _spawnRangeX = 20;
    private float _spawnPositionZ = 20;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            var animalPrefab = animalPrefabs[Random.Range(0, animalPrefabs.Length)];
            var spawnPosition = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), 0, _spawnPositionZ);
            Instantiate(
                animalPrefab,
                spawnPosition,
                animalPrefab.transform.rotation
            );
        }
    }
}