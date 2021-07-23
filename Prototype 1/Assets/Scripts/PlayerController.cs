using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 20.0f;
    private float _turnSpeed = 45.0f;
    private float _horizontalInput;
    private float _forwardInput;

    void FixedUpdate()
    {
        // Allow overwrite from user key press
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");
        
        // Move car forward
        transform.Translate(Vector3.forward * (Time.deltaTime * speed * _forwardInput));
        
        // Steer the car using input
        transform.Rotate(Vector3.up * (Time.deltaTime * _turnSpeed * _horizontalInput));
    }
}
