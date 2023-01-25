using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPosition = new Vector3(20f, 0f, 0f);

    private float startDelay = 2f;

    private float spawnInterval = 2f;
    
    private PlayerController playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle",startDelay,spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnObstacle()
    {
        if(!playerController.isGameOver) Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
    }
}
