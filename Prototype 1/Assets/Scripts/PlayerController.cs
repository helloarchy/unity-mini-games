﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower = 0;
    private float _turnSpeed = 45.0f;
    private float _horizontalInput;
    private float _forwardInput;
    private Rigidbody _playerRb;
    [SerializeField] private GameObject centreOfMass;


    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playerRb.centerOfMass = centreOfMass.transform.position;
    }

    void FixedUpdate()
    {
        // Allow overwrite from user key press
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");
        
        // Move car forward
        // transform.Translate(Vector3.forward * (Time.deltaTime * horsePower * _forwardInput));
        _playerRb.AddRelativeForce(Vector3.forward * (Time.deltaTime * horsePower * _forwardInput));
        
        // Steer the car using input
        transform.Rotate(Vector3.up * (Time.deltaTime * _turnSpeed * _horizontalInput));
    }
}
