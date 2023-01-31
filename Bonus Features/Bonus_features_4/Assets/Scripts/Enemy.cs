using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody enemyRb;
    
    [SerializeField]
    private float speed; // 3f

    private float forceFactor = 6f;
        
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.name == "Harder Enemy")
        {
            Rigidbody playerRb = player.GetComponent<Rigidbody>();
            Vector3 forceDirection = player.transform.position - transform.position;
            playerRb.AddForce(forceDirection * forceFactor, ForceMode.Impulse);
        }
    }
}
