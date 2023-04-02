using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawnBehaviour : MonoBehaviour
{

    private float spawnTimer;
    private int objectCount;  // new variable to keep track of the number of spawned objects


    // Spawning

    public GameObject[] objectToSpawn;
    public float spawnInterval = 9f;
    public Vector3 spawnPositionOffset;

    private GameObject spawnedObject;


    public GameObject[] collectibleObjects;

    
    void Start()
    {

        spawnTimer = 0;
        objectCount = 0;  // initialize object count to 0

        StartCoroutine(SpawnObject());
    }

    public void Update()
    {
       

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            Vector3 spawnPosition = transform.position + spawnPositionOffset;
            spawnedObject = Instantiate(objectToSpawn[0], spawnPosition, Quaternion.identity);

            // increment object count
            objectCount++;
           

            Destroy(spawnedObject, 12f);


            spawnTimer = 0;
            
        }



        if (spawnedObject != null) // check if spawnedObject is not null
        {
            CollectibeleSpawnBehaviour(spawnedObject);
        }
        Debug.Log("Object count: " + objectCount);
    }




   
        public void CollectibeleSpawnBehaviour(GameObject obj)
        {
            if (obj == null)
            {
                return;
            }

            if (obj.activeSelf)
            {
                if (objectCount % 2 == 0)
                {
                    if (collectibleObjects[0] != null)
                    {
                        collectibleObjects[0].SetActive(false);
                    }
                    if (collectibleObjects[2] != null)
                    {
                        collectibleObjects[2].SetActive(true);
                    }
                }
               
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
