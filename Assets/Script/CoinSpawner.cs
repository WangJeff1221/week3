using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 3f;

    void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            int randomLane = Random.Range(0, spawnPoints.Length);
            Instantiate(coinPrefab, spawnPoints[randomLane].position, Quaternion.identity);
        }
    }
}
