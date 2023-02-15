using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public bool isActive = true;
    public float speed = 5f;
    private float zRange = 3f;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            MoveBall();
        }
    }

    private void MoveBall()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
    
        // Translate in local space by default.
        transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * speed);
        
        if (transform.position.z > 3f)
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        
        if (transform.position.z < -3f)
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        gameManager.UpdateCounter(1);
        Destroy(gameObject,2f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject,2f);
        }
    }
}
