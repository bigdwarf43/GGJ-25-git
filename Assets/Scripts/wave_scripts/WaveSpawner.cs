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

    private void Awake()
    {
        currentWave = waves[i]; // Spawning the first wave
        timeBtwnSpawns = currentWave.TimeBeforeThisWave;
    }

    private void Update()
    {
        if (stopSpawning)
        {
            return;
        }

        if (Time.time >= timeBtwnSpawns)
        {
            SpawnWave();
            IncWave();

            timeBtwnSpawns = Time.time + currentWave.TimeBeforeThisWave;
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

    private Vector2 SnapDirection(Vector2 direction)
    {
        // Snap the direction to (1, 0), (0, 1), (-1, 0), or (0, -1)
        float x = Mathf.Abs(direction.x) > 0.5f ? Mathf.Sign(direction.x) : 0f;
        float y = Mathf.Abs(direction.y) > 0.5f ? Mathf.Sign(direction.y) : 0f;

        return new Vector2(x, y);
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
