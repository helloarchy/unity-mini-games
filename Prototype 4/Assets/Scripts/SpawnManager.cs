using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRange = 9;
    
    // Start is called before the first frame update
    void Start()
    {
        var randomPosition = GetRandomPosition();
        Instantiate(enemyPrefab, randomPosition, enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GetRandomPosition()
    {
        var spawnX = Random.Range(-spawnRange, spawnRange);
        var spawnY = Random.Range(-spawnRange, spawnRange);

         return new Vector3(spawnX, 0, spawnY);
    }
}
