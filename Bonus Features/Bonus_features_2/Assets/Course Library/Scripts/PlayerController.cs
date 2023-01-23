using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    
    [SerializeField] private float movementSpeed = 5f;

    [SerializeField] private float xRange = 10f;

    [SerializeField] private float lowerZRange = -1.8f;
    [SerializeField] private float upperZRange = 16.65f;
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

        if (transform.position.z < lowerZRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, lowerZRange);
        }
        else if(transform.position.z > upperZRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, upperZRange);
        }
        
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * movementSpeed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * movementSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab,transform.position,projectilePrefab.transform.rotation);
        }
    }
}
