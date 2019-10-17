using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    private float startDelay = 0;
    private float spawnInterval = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAsteroid", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnAsteroid()
    {

        Instantiate(asteroidPrefab, transform.position, Quaternion.Euler(0, 0, 0));
    }
}
