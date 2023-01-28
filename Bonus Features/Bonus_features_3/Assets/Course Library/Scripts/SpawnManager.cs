using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
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
    
    void SpawnObstacle()
    {
        int index = Random.Range(0, obstaclePrefabs.Length);
        if (!playerController.isGameOver)
        {
            Instantiate(obstaclePrefabs[index], spawnPosition, obstaclePrefabs[index].transform.rotation);
        }
    }
}
