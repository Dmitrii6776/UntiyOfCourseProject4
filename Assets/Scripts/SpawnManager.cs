using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private int spawnRange = 9;
    private int enemyCount;

    private int waveCount = 1;

    [SerializeField] private GameObject powerUpPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
        SpawnEnemys(waveCount);
        SpawnPowerUp();
    }

    public void SpawnEnemys(int EnemyToSpawn)
    {
        for (int i = 0; i < EnemyToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPos;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyControl>().Length;
        if (enemyCount < 1)
        {
            waveCount++;
            SpawnEnemys(waveCount);
            SpawnPowerUp();
        }
    }

    private void SpawnPowerUp()
    {
        Instantiate(powerUpPrefab, GenerateSpawnPos(), powerUpPrefab.transform.rotation);
    }
}
