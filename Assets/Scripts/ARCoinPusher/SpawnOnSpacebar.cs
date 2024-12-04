using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnSpacebar : MonoBehaviour
{
    [Header("Prefab to Spawn")]
    public GameObject prefab;

    [Header("Spawn Settings")]
    public Vector3 spawnOffset = Vector3.zero; // Position offset relative to the spawner

    void Update()
    {
        // Check for the Spacebar key press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPrefab();
        }
    }

    private void SpawnPrefab()
    {
        if (prefab != null)
        {
            // Spawn the prefab at the GameObject's position plus the offset
            Instantiate(prefab, transform.position + spawnOffset, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Prefab is not assigned!");
        }
    }
}
