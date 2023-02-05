using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] powerupPrefab;
    public GameObject bossEnemy;
    private float spawnRange = 9f;
    private int enemyCount;
    public int bossRound;
    
    [HideInInspector]
    public int waveSize = 1;
    
    
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
            waveSize++;

            if (waveSize % bossRound == 0) // Boss fight
            {
                SpawnBossEnemy();
            }
            else
            {
                SpawnEnemyWave(waveSize);
            }
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
            index = Random.Range(0, enemyPrefab.Length);
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

    void SpawnBossEnemy()
    {
        Instantiate(bossEnemy, new Vector3(0f,.7f,0f), bossEnemy.transform.rotation);
    }

    public void MiniEnemySpawn(int miniEnemyCount)
    {
        for (int i = 0; i < miniEnemyCount; i++)
        {
            int index = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[index], GenerateSpawnPosition(), enemyPrefab[index].transform.rotation);
        }
    }
}
