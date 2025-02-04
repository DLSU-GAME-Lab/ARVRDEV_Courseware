using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroids;

    private float spawnFieldX = 15f;
    private float spawnFieldY = 10f;
    private float spawnFieldZ = 30f;
    private float spawnInterval = 3f;

    private void Start()
    {
        StartCoroutine(SpawnOnInterval());
    }

    void Update()
    {

    }

    private void SpawnAsteroid()
    {
        int toSpawn = Random.Range(0, asteroids.Length);
        float spawnX = Random.Range(-spawnFieldX, spawnFieldX) + Camera.main.transform.position.x;
        float spawnY = Random.Range(-spawnFieldY, spawnFieldY) + Camera.main.transform.position.y;
        Vector3 spawnPos = (Camera.main.transform.forward * spawnFieldZ) + new Vector3(spawnX, spawnY, Camera.main.transform.position.z);

        Instantiate(asteroids[toSpawn], spawnPos, Random.rotation, this.transform);
    }

    IEnumerator SpawnOnInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            if (AsteroidBehaviour.GetCount() <= 4)
            {
                SpawnAsteroid();
            }
        }
    }
}
