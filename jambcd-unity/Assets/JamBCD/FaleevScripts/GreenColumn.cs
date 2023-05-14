using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenColumn : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform player;
    public float spawnDistanceThreshold = 10f;


private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Could not find player object");
        }
    }


    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < spawnDistanceThreshold)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }
}
