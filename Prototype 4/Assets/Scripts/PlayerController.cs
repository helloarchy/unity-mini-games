using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;
    private GameObject _focalPoint;

    public bool hasPowerUp = false;
    public float speed = 5.0f;
    public float powerUpStrength = 15;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        var forwardInput = Input.GetAxis("Vertical");
        _playerRb.AddForce(_focalPoint.transform.forward * (forwardInput * speed));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Debug.Log($"Collided with {other.gameObject.tag} while power up is {hasPowerUp}");
            var enemyRb = other.gameObject.GetComponent<Rigidbody>();
            var reboundDirection = enemyRb.transform.position - transform.position;
            enemyRb.AddForce(reboundDirection.normalized * powerUpStrength, ForceMode.Impulse);
        }
    }
}
