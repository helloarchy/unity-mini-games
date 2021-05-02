using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float _topBound = 30;
    private float _bottomBound = -10;

    void Update()
    {
        // If an object goes out of the screen, destroy it
        if (transform.position.z > _topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < _bottomBound)
        {
            Debug.Log("Game over!");
            Destroy(gameObject);
        }
    }
}