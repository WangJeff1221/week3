using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform[] spawnPoints; 
    public float spawnInterval = 3f;

    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            int randomLane = Random.Range(0, spawnPoints.Length);
            Instantiate(obstaclePrefab, spawnPoints[randomLane].position, Quaternion.identity);
        }
    }
}
