using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4.25f;
    private float ySpawnPos = -2;
    
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(),ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }
    
    private void OnMouseDown() 
    {
        Destroy(gameObject);    
    }

    private void OnTriggerEnter(Collider other) 
    {
        Destroy(gameObject);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    Vector3 RandomTorque()
    {
        return new Vector3(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque),
            Random.Range(-maxTorque, maxTorque));
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
