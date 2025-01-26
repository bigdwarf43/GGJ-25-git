using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;

    private Wave currentWave;

    private float timeBtwnSpawns;
    private int i = 0;

    private bool stopSpawning = false;

    void Start()
    {
        i = 0;
        currentWave = waves[i]; // Spawning the first wave
        timeBtwnSpawns = Time.time + currentWave.TimeBeforeThisWave;
    }

    void Update()
    {
        if (GameManager.Instance.isGameRunning)
        {
            if (stopSpawning)
            {
                return;
            }

            if (Time.time >= timeBtwnSpawns)
            {
                SpawnWave();
                Debug.Log($"spawned wave: {i}");
                IncWave();

                timeBtwnSpawns = Time.time + currentWave.TimeBeforeThisWave;
            }
        }
        
    }

    private void SpawnWave()
    {
        for (int i = 0; i < currentWave.EnemiesInWave.Length; i++) // spawn all the enemies in this wave
        {
 
            EnemyData enemyDetails = currentWave.EnemiesInWave[i];

            var enemy= Instantiate(enemyDetails.EnemyPrefab, enemyDetails.spawnPoint, enemyDetails.EnemyPrefab.transform.rotation);


            // Set the enemy direction and the speed
            enemy.transform.GetComponent<Bullet>().dir = enemyDetails.direction;
            enemy.transform.GetComponent<Bullet>().speed = enemyDetails.speed;

        }
    }


    private void IncWave()
    {
        if (i + 1 < waves.Length)
        {
            i++;
            currentWave = waves[i];
        }
        else
        {
            stopSpawning = true;
        }
    }



}
