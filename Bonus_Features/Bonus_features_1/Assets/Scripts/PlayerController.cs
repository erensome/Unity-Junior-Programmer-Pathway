using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float speed = 20f;

    [SerializeField] private float turnSpeed = 15f;

    [SerializeField] private float horizontalInput;

    [SerializeField] private float verticalInput;

    [SerializeField] private bool isPlayerOne = true;
    
    // Update is called once per frame
    void Update()
    {
        if (isPlayerOne)
        {
            // This is where we get player input
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        
            // Moves the car based on vertical input
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        
            // Rotates the car based on horizontal input
            transform.Rotate(Vector3.up ,Time.deltaTime * turnSpeed * horizontalInput);
        }
        else
        {
            // This is where we get player input
            horizontalInput = Input.GetAxis("Horizontal2");
            verticalInput = Input.GetAxis("Vertical2");
        
            // Moves the car based on vertical input
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        
            // Rotates the car based on horizontal input
            transform.Rotate(Vector3.up ,Time.deltaTime * turnSpeed * horizontalInput);
        }
        
    }
}
