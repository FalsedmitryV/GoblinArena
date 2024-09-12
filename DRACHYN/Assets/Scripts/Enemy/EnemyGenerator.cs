using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject waveManager;
    [SerializeField] private GameObject[] enemyType;
    [SerializeField] private GameObject[] enemisOnWave;
    [SerializeField] private GameObject[] bosses;
    [SerializeField] private int enemyCount;
    [SerializeField] private Vector2[] enemySpawnPoint;
    private int enemyRandomSpawnPoint;
    [SerializeField] private int numberOfBoss = 0;
    private void Start()
    {
        RespawnMaxEnemy();
        waveManager = GameObject.Find("WaveManager");
    }

    public void RespawnEnemy()
    { 
        enemisOnWave = GameObject.FindGameObjectsWithTag("enemyM");

        if (enemisOnWave.Length < enemyCount)
        {
            enemyRandomSpawnPoint = Random.Range(0, 4);
            int enemyRandomType = Random.Range(0, enemyType.Length);
            Vector3 position = new Vector3(enemySpawnPoint[enemyRandomSpawnPoint].x, 1.67f, enemySpawnPoint[enemyRandomSpawnPoint].y);
            GameObject enemy = Instantiate(enemyType[enemyRandomType], position, Quaternion.identity);
        }
    }

    public void RespawnMaxEnemy()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            enemyRandomSpawnPoint = Random.Range(0, 4);
            int enemyRandomType = Random.Range(0, enemyType.Length);
            Vector3 position = new Vector3(enemySpawnPoint[enemyRandomSpawnPoint].x, 1.67f, enemySpawnPoint[enemyRandomSpawnPoint].y);
            GameObject enemy = Instantiate(enemyType[enemyRandomType], position, Quaternion.identity);
        }
    }

    public void SpawnBoss()
    {
        Debug.Log("босс");
        GameObject enemy = Instantiate(bosses[numberOfBoss], new Vector3(5f, 1.67f, 25f), Quaternion.identity);
        numberOfBoss++;
    }
}
