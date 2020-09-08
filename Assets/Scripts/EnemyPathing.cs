using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    // Configuration Parameters
    WaveConfiguration waveConfiguration;
    List<Transform> waypoints;
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfiguration.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfiguration(WaveConfiguration waveConfiguration)
    {
        this.waveConfiguration = waveConfiguration;
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            // Get target position and set movement
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfiguration.GetMoveSpeed() * Time.deltaTime;

            // Set new position
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            // Increase waypointIndex variable
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            // Destroy the path after it ran
            Destroy(gameObject);
        }
    }
}
