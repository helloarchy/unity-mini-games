using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;
    public float floatForce;

    private Rigidbody _playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource _playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;

    private float gravityModifier = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        _playerAudio = GetComponent<AudioSource>();
        _playerRb = GetComponent<Rigidbody>();
        _playerAudio = GetComponent<AudioSource>();
        
        // Apply a small upward force at the start of the game
        _playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        bool isInBounds = CheckIfInBounds();
        
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && isInBounds)
        {
            _playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }
    }


    private bool CheckIfInBounds()
    {
        var positionY = transform.position.y;
        return positionY < 12.5f && positionY > -1;
    }
    

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"Collided with {other.gameObject.tag}");
        
        
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            _playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            _playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
        }

        // if player collides with ground, bounce
        else if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("So I should bounce now...");
            
            _playerRb.AddForce(Vector3.up * floatForce * 10, ForceMode.Impulse);
            _playerAudio.PlayOneShot(bounceSound, 1.0f);
        }
    }

}
