using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    public int pointValue;
    public ParticleSystem explostionParticle;
    
    private Rigidbody _targetRb;
    private GameManager _gameManager;
    
    private float _minSpeed = 12;
    private float _maxSpeed = 16;
    private float _maxTorque = 10;
    private float _xRange = 4;
    private float _ySpawnPos = -2; 
    
    // Start is called before the first frame update
    void Start()
    {
        _targetRb = GetComponent<Rigidbody>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        _targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        _targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    /**
     * Automatically knows if mouse on gameObject.
     */
    private void OnMouseDown()
    {
        Destroy(gameObject);
        _gameManager.UpdateScore(pointValue);
        Instantiate(explostionParticle, transform.position, explostionParticle.transform.rotation);
    }

    /**
     * Automatically knows if it enters another objects onTrigger collider
     */
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-_xRange, _xRange), _ySpawnPos);
    }
}
