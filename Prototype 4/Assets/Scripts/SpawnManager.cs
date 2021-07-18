using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRange = 9;
    public int enemyCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(3);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {
            SpawnEnemyWave(1);
        }
    }

    private Vector3 GetRandomPosition()
    {
        var spawnX = Random.Range(-spawnRange, spawnRange);
        var spawnY = Random.Range(-spawnRange, spawnRange);

         return new Vector3(spawnX, 0, spawnY);
    }

    private void SpawnEnemyWave(int numEnemies)
    {
        Debug.Log($"Spawning {numEnemies} enemies");
        for (int i = 0; i < numEnemies; i++)
        {
            Instantiate(enemyPrefab, GetRandomPosition(), enemyPrefab.transform.rotation);
        }
    }
}
