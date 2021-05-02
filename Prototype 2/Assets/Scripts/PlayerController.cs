using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float horizontalMoveLimit = 10.0f;
    public GameObject projectilePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RestrictToBoundary(transform.position);

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * (Time.deltaTime * speed * horizontalInput));
    }

    /**
     * Limit the player movement to the boundary limits
     */
    private void RestrictToBoundary(Vector3 position)
    {
        if (position.x < -horizontalMoveLimit)
        {
            position = new Vector3(-horizontalMoveLimit, position.y, position.z);
        }
        else if (position.x > horizontalMoveLimit)
        {
            position = new Vector3(horizontalMoveLimit, position.y, position.z);
        }

        transform.position = position;
    }
}
