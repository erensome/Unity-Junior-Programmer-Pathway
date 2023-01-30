using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject powerupPrefab;

    private float zEnemySpawn = 17;
    private float xEnemySpawn = 14;

    private float zPowerSpawn = 8;
    private float xPowerSpawn = 10;
    
    private float enemySpawnTime = 1.5f;
    private float powerupSpawnTime = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy",2f,enemySpawnTime);
        InvokeRepeating("SpawnPowerup",3f,powerupSpawnTime);
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 enemySpawnPos = new Vector3(Random.Range(-xEnemySpawn, xEnemySpawn), 0.6f, zEnemySpawn);
        Instantiate(enemyPrefabs[randomIndex], enemySpawnPos, enemyPrefabs[randomIndex].transform.rotation);
    }

    void SpawnPowerup()
    {
        Vector3 powerupSpawnPos = new Vector3(Random.Range(-xPowerSpawn, xPowerSpawn), 0f,
            Random.Range(-zPowerSpawn, zPowerSpawn));
        Instantiate(powerupPrefab, powerupSpawnPos, powerupPrefab.transform.rotation);
    }
}
