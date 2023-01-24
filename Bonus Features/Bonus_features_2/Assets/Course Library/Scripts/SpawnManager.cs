using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    [SerializeField] float startDelay = 2f;
    
    [SerializeField] private float spawnInterval = 1f;

    private float spawnX = 17f;
    private float spawnZ = 20f;
    

    private void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimals),startDelay,spawnInterval);
    }

    void SpawnRandomAnimals()
    {
        // Up to down
        Vector3 firstSpawn = new Vector3(Random.Range(-spawnX, spawnX), 0f, spawnZ);
        // Left to right -  z value must be between 0 and 16, Otherwise it won't be displayed in the game screen
        Vector3 secondSpawn = new Vector3(-spawnX, 0f, Random.Range(0,16));
        // Right to left
        Vector3 thirdSpawn = new Vector3(spawnX, 0f, Random.Range(0,16));
        
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], firstSpawn, Quaternion.Euler(0f,180f,0f));
        
        animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], secondSpawn, Quaternion.Euler(0f,90f,0f));
        
        animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], thirdSpawn, Quaternion.Euler(0f,270f,0f));
    }
}
