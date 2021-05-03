using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveLeft : MonoBehaviour
{
    public float moveSpeed = 30.0f;

    void Update()
    {
        transform.Translate(Vector3.left * (Time.deltaTime * moveSpeed));
    }
}