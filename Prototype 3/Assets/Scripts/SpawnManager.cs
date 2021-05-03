using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float startDelay = 2;
    public float repeatRate = 2;

    private readonly Vector3 _spawnPosition = new Vector3(25, 0, 0);

    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, _spawnPosition, obstaclePrefab.transform.rotation);
    }
}