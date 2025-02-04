using System.Collections;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [Header("Prefab to Spawn")]
    public GameObject prefab;

    [Header("Spawn Settings")]
    public int spawnCount = 50;        // Total number of prefabs to spawn
    public float spawnInterval = 0.1f; // Interval between spawns in seconds
    public Vector3 spawnPosition = Vector3.zero; // Position offset for spawning

    private int spawnedCount = 0;      // Track how many prefabs have been spawned

    private void Start()
    {
        // Start the spawning process
        StartCoroutine(SpawnPrefabs());
    }

    private IEnumerator SpawnPrefabs()
    {
        while (spawnedCount < spawnCount)
        {
            SpawnPrefab();
            spawnedCount++;

            // Wait for the interval before spawning the next prefab
            yield return new WaitForSeconds(spawnInterval);
        }

        // Stop spawning once the desired count is reached
        Debug.Log("Finished spawning all prefabs.");
    }

    private void SpawnPrefab()
    {
        if (prefab != null)
        {
            // Instantiate the prefab at the given position and rotation
            Instantiate(prefab, transform.position + spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Prefab is not assigned!");
        }
    }
}
