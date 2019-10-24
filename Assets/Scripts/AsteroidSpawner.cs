using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    private float startDelay = 0;
    private float spawnInterval = 5.0f;
    private float r;

    // Start is called before the first frame update
    void Start()
    {
        //Invokes the SpawnAsteroid method after the startDelay and repeats on the spawnInterval
        InvokeRepeating("SpawnAsteroid", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAsteroid()
    {
        //Random angle range to spawn the asteroids in
        r = Random.Range(-60, 60);

        //Spawns an asteroid at the spawners position and rotaion set by r
        Instantiate(asteroidPrefab, transform.position, Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + r));
    }
}
