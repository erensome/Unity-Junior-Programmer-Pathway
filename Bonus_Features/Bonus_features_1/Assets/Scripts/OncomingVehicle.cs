using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OncomingVehicle : MonoBehaviour
{
    [SerializeField]
    private float speed = 9f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
