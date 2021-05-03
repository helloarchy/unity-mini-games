using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float _spawnRangeX = 20;
    private float _spawnPositionZ = 20;
    private float _startDelay = 2;
    private float _spawnInterval = 1.5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimal), _startDelay, _spawnInterval);
    }

    void SpawnRandomAnimal()
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