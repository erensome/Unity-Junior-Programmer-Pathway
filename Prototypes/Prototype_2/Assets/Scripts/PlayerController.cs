using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;

    [SerializeField] private float movementSpeed = 5f;

    [SerializeField] private float xRange = 10f;
    
    public GameObject projectilePrefab;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * movementSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab,transform.position,projectilePrefab.transform.rotation);
        }
    }
}
