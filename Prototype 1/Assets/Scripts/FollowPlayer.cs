using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 5, -7);

    void LateUpdate()
    {
        // Set position to our players position, with an offset
        transform.position = player.transform.position + offset;
    }
}
