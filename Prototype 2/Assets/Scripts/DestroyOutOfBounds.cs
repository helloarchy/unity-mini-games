using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float _topBound = 30;
    private float _bottomBound = -10;
    
    void Update()
    {
        if (transform.position.z > _topBound || transform.position.z < _bottomBound)
        {
            Destroy(gameObject);
        }
    }
}
