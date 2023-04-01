using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawnBehaviour : MonoBehaviour
{
   
    private float spawnTimer;  // new variable to keep track of time since last spawn


    // Spawning

    public GameObject[] objectToSpawn;
    public float spawnInterval = 9f;
    public Vector3 spawnPositionOffset;

    private GameObject spawnedObject;


   
    void Start()
    {
     
        spawnTimer = 0;

       

        StartCoroutine(SpawnObject());
    }

    public void Update()
    {
       

       

        // check if it's time to spawn a new object
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            Vector3 spawnPosition = transform.position + spawnPositionOffset;
            spawnedObject = Instantiate(objectToSpawn[0], spawnPosition, Quaternion.identity);

            Destroy(spawnedObject,12f); //spawner destroy

            spawnTimer = 0;  // reset the timer

        }
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return null;  // don't do anything in this coroutine
        }
    }

}
