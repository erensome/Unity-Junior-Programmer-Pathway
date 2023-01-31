using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] powerupPrefab;
    private float spawnRange = 9f;
    private int enemyCount;
    private int waveSize = 1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveSize);
        SpawnPowerUp();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            SpawnEnemyWave(++waveSize);
            SpawnPowerUp();
        }
    }

    void SpawnPowerUp()
    {
        int index = Random.Range(0, powerupPrefab.Length);
        GameObject newPowerup = Instantiate(powerupPrefab[index], GenerateSpawnPosition(),
            powerupPrefab[index].transform.rotation);
    }

    void SpawnEnemyWave(int waveCount)
    {
        int index = 0;
        for (int i = 0; i < waveCount; i++)
        {
            if (waveCount == 5 && i == 0)
            {
                index = enemyPrefab.Length - 1;
            }
            else if (waveCount > 3)
            {
                index = Random.Range(0, enemyPrefab.Length - 1);
            }
            else if (waveCount >= 2)
            {
                index = Random.Range(0, 2);
            }
            Instantiate(enemyPrefab[index], GenerateSpawnPosition(), enemyPrefab[index].transform.rotation);
        }
    }

    // Get Random Enemy Index
    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0f, spawnPosZ);
        return randomPos;
    }
}
