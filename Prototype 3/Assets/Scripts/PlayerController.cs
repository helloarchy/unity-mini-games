using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    public bool isGrounded;
    public bool isGameOver = false;
    public ParticleSystem ParticleSystem;
    
    private Animator _playerAnimator;
    private Rigidbody _playerRigidbody;

    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isGameOver)
        {
            _playerAnimator.SetTrigger("Jump_trig");
            
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

            _playerAnimator.SetBool("Death_b", true);
            _playerAnimator.SetInteger("DeathType_int", 1);
            
            ParticleSystem.Play();
        }
    }
}