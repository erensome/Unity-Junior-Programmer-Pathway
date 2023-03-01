using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody enemyRb;
    private SpawnManager spawnManager;
    private GameManager gameManager;
    
    [SerializeField]
    private float speed; // 3f
    private float forceFactor = 6f;
    private float nextSpawn;
    public float miniSpawnInterval;
    public bool isBoss = false;
    
        
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if (isBoss) spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }

        if (!gameManager.isGameOver)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);
        }

        if (isBoss)
        {
            if (Time.time >= nextSpawn)
            {
                spawnManager.MiniEnemySpawn(spawnManager.waveSize / spawnManager.bossRound);
                nextSpawn = Time.time + miniSpawnInterval;
            }
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
