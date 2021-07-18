using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float minY = -10;
    
    private Rigidbody _enemyRb;
    private GameObject _player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var playerDirection = _player.transform.position - transform.position;
        _enemyRb.AddForce(playerDirection.normalized * speed);

        if (transform.position.y < minY)
        {
            Debug.Log($"Destroying enemy at height {transform.position.y}");
            Destroy(gameObject);
        }
    }
}
