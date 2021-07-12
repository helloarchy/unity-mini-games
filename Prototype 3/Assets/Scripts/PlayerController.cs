using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    public bool isGrounded;
    public bool isGameOver = false;
    
    public ParticleSystem particleExplosion;
    public ParticleSystem particleDirtTrail;

    public AudioClip soundJump;
    public AudioClip soundCrash;
    
    private Animator _playerAnimator;
    private Rigidbody _playerRigidbody;
    private AudioSource _playerAudio;

    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody>();
        _playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isGameOver)
        {
            _playerAnimator.SetTrigger("Jump_trig");
            
            _playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            
            particleDirtTrail.Stop();
            _playerAudio.PlayOneShot(soundJump, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            particleDirtTrail.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game over!");
            isGameOver = true;

            _playerAnimator.SetBool("Death_b", true);
            _playerAnimator.SetInteger("DeathType_int", 1);
            
            particleExplosion.Play();
            particleDirtTrail.Stop();
            _playerAudio.PlayOneShot(soundCrash, 1.0f);
        }
    }
}