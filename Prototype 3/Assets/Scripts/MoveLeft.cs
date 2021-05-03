using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float moveSpeed = 30.0f;
    private PlayerController _playerController;

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
    }
}