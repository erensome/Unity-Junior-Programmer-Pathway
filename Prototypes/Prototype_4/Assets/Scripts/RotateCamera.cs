using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * rotateSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(transform.rotation.eulerAngles);
        }
    }
}
