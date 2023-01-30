using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 5f;
    public float zBound = 13;
    private Rigidbody enemyRb;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce(Vector3.forward * -speed);
        if (transform.position.z < -zBound)
        {
            Destroy(gameObject);
        }
    }
}
