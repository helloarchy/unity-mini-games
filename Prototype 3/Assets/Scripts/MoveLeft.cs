using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float moveSpeed = 50.0f;
    private PlayerController _playerController;
    private readonly float _leftBound = -15;

    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (_playerController.isGameOver == false)
        {
            transform.Translate(Vector3.left * (Time.deltaTime * moveSpeed));
        }

        if (transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}