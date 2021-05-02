using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 20.0f;
    private float _turnSpeed = 45.0f;
    private float _horizontalInput;
    private float _forwardInput;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Allow overwrite from user key press
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");
        
        // Move car forward
        transform.Translate(Vector3.forward * (Time.deltaTime * _speed * _forwardInput));
        
        // Steer the car using input
        transform.Rotate(Vector3.up * (Time.deltaTime * _turnSpeed * _horizontalInput));
    }
}
