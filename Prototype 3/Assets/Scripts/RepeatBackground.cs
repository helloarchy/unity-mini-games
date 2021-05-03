using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    public float xOffset = 50.0f;
    private Vector3 _startPosition;
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < (_startPosition.x - xOffset))
        {
            transform.position = _startPosition;
        }
    }
}
