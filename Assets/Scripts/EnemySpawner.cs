using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] List<WaveConfiguration> waveConfigurations;

    // Variables
    int startingWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        var currentWave = waveConfigurations[startingWave];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfiguration waveConfiguration)
    {
        for (int enemyCount = 0; enemyCount < waveConfiguration.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(
            waveConfiguration.GetEnemyPrefab(),
            waveConfiguration.GetWaypoints()[0].transform.position,
            Quaternion.identity
            );

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfiguration(waveConfiguration);

            yield return new WaitForSeconds(waveConfiguration.GetSpawnIntervalTime());
        }
    }
}
