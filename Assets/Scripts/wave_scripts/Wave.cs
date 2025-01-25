using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    [field: SerializeField]
    public GameObject EnemyPrefab { get; private set; }

    [field: SerializeField]
    public float speed { get; private set; }

    [field: SerializeField]
    public Vector2 spawnPoint{ get; private set; }
}

[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/Waves", order = 1)]
public class Wave : ScriptableObject
{

    [field: SerializeField]
    public float TimeBeforeThisWave { get; private set; }

    [field: SerializeField]
    public EnemyData[] EnemiesInWave { get; private set; }

}