using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    public bool isGrounded;
    public bool isGameOver = false;

    private Rigidbody _playerRigidbody;

    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game over!");
            isGameOver = true;
        }
    }
}