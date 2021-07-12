using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float startDelay = 2;
    public float repeatRate = 2;

    private readonly Vector3 _spawnPosition = new Vector3(30, 0, 0);
    private PlayerController _playerController;

    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        if (_playerController.isGameOver == false)
        {
            Instantiate(obstaclePrefab, _spawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}