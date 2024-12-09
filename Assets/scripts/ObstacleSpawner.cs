using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles; // Array of obstacle prefabs
    public float spawnRate = 2f;  // Time between spawns
    private Vector3 spawnPos;     // Position for spawning obstacles

    void Start()
    {
        spawnPos = transform.position; // Initialize spawn position
        StartCoroutine(SpawnObstacles()); // Start spawning obstacles
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            Spawn(); // Spawn an obstacle

            GameManager.instance.UpdateScore();
            yield return new WaitForSeconds(spawnRate); // Wait for next spawn
        }
    }

    void Spawn()
    {
        // Reset spawn position
        spawnPos = transform.position;

        // Select a random obstacle and position
        int randObstacle = Random.Range(0, obstacles.Length); // Random obstacle index
        int randomSpot = Random.Range(0, 2); // 0 for bottom, 1 for top

        if (randomSpot < 1)
        {
            // Bottom spawn (default y-position)
            spawnPos.y = transform.position.y;
        }
        else
        {
            // Top spawn (negate y-position)
            spawnPos.y = -transform.position.y;
        }

        // Instantiate the obstacle at the calculated position
        GameObject obs = Instantiate(obstacles[randObstacle], spawnPos, Quaternion.identity);

        // Adjust rotation based on spawn position
        if (spawnPos.y < 0) // Bottom spawn
        {
            obs.transform.eulerAngles = new Vector3(0, 0, 180); // Upside down for bottom
        }
        else // Top spawn
        {
            obs.transform.eulerAngles = Vector3.zero; // Default rotation for top
        }
    }
}
