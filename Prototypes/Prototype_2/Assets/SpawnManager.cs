using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float spawnRangeX = 20f;

    private float spawnRangeZ = 20f;

    [SerializeField] float startDelay = 2f;
    
    [SerializeField] private float spawnInterval = 1f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimals),startDelay,spawnInterval);
    }

    void SpawnRandomAnimals()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0f, spawnRangeZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
