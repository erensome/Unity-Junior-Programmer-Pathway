using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float elapsedTime;
    private float dogSpawnInterval = 1f;
    
    private void Start()
    {
        elapsedTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && elapsedTime >= dogSpawnInterval)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            elapsedTime = 0f;
        }
    }
}
