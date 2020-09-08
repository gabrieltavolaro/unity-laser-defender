using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Configuration")]
public class WaveConfiguration : ScriptableObject
{
    // Configuration parameters
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;

    [SerializeField] float spawnIntervalTime = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;

    [SerializeField] int numberOfEnemies = 5;

    [SerializeField] float moveSpeed = 2f;

    // Get methods
    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);

        }

        return waveWaypoints;
    }

    public float GetSpawnIntervalTime() { return spawnIntervalTime; }

    public float GetSpawnRandomFactor() { return spawnRandomFactor; }

    public int GetNumberOfEnemies() { return numberOfEnemies; }

    public float GetMoveSpeed() { return moveSpeed; }

}
