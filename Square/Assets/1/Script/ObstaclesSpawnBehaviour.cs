using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawnBehaviour : MonoBehaviour
{

    private float spawnTimer;
    public int objectCount;  
    public GameObject[] objectToSpawn;
    public float spawnInterval = 9f;
    public Vector3 spawnPositionOffset;
   // private GameObject spawnedObject;
   public Collectible collectible;

    bool spawningStart = false;
    public RedBall redBall;

    private float destroyInstant ;
    void Start()
    {
       
        spawnTimer = 0;
        objectCount = 0;   
        spawningStart = false;

        

    }
    public void Update()
    {
        
        if (redBall.stopball)
            return;
        
        
        if(spawningStart)
        {
            Debug.Log("spwannn");

            collectible.collectibleSpawning();
        }
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            Vector3 spawnPosition = transform.position + spawnPositionOffset;
            int randomIndex = Random.Range(0, objectToSpawn.Length);
         GameObject  spawnedObject = Instantiate(objectToSpawn[randomIndex], spawnPosition, Quaternion.identity);


            //spawnedObject = Instantiate(objectToSpawn[0], spawnPosition, Quaternion.identity);
            objectCount++;
            Debug.Log("Object count: " + objectCount);
            if (objectCount > Random.Range(5,10)  )
            {
             spawningStart = true;
              
                
            }
            
           if(redBall.stopball)
            {
                destroyInstant = 0f;
                Destroy(spawnedObject, destroyInstant);
                spawnTimer = 0;
                return;
            }

            if (!redBall.stopball)
            {
                destroyInstant = 8f;
                Destroy(spawnedObject, destroyInstant);
                spawnTimer = 0;
            }

           
        }
        

    }

  

   
}


