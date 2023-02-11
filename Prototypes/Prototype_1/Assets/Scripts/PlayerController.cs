using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    //[SerializeField] private float speed = 20f;

    [SerializeField] private float horsePower = 0f;
    [SerializeField] private float turnSpeed = 5f;
    private float rpm;
    private float horizontalInput;
    private float verticalInput;
    
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;
    private int wheelsOnGround;
    private Rigidbody playerRb;
    private float speed;
    private WheelCollider _wheelCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // This is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            // Moves the car based on vertical input
            // transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            // Moves the car based on vertical input and physics
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);

            // Rotates the car based on horizontal input
            transform.Rotate(Vector3.up ,Time.deltaTime * turnSpeed * horizontalInput);
            // Rigidbody.velocity.magnitude returns speed in m/s
            // To get the speed in km/h multiply the magnitude by 3.6
            speed = (playerRb.velocity.magnitude) * 3.6f;
            speedometerText.text = $"Speed: {Mathf.RoundToInt(speed).ToString()} km/h";

            rpm = (speed % 30) * 40;
            rpmText.SetText($"RPM: {Mathf.RoundToInt(rpm)}");
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;

        foreach (WheelCollider wheel in allWheels)
        {
            if (!wheel.isGrounded) return false;
        }
        return true;
    }
}
