using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float dogSpawnDelay = 2.0f;

    private float _timeSinceDogSpawn = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // On space bar press, send dog. Throttle spawns to once per delay period
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - _timeSinceDogSpawn > dogSpawnDelay)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            _timeSinceDogSpawn = Time.time;
        }
    }
}
