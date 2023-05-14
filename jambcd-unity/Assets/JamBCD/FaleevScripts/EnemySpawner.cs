using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject EnemyPrefab;
    public Transform[] SpawnPoints;
    public float SpawnInterval = 1f;

    private void Start() {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies() {
        while (true) {
            // Choose a random spawn point from the array
            var spawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];

            // Instantiate a new enemy at the chosen spawn point
            Instantiate(EnemyPrefab, spawnPoint.position, spawnPoint.rotation);

            yield return new WaitForSeconds(SpawnInterval);
        }
    }
}