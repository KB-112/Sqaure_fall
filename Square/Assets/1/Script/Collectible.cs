using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private float spawnTimer;
    private int objectCount;
    public GameObject[] objectToSpawn;
    public float spawnInterval = 9f;
    
    [Header("SPAWN COORDINATES")]
    public Vector3 spawnPositionOffset;
    public Vector3 spawnCorner1; // First corner of the spawn area
    public Vector3 spawnCorner2; // Second corner of the spawn area
    public Vector3 spawnCorner3; // Third corner of the spawn area
    public Vector3 spawnCorner4; // Fourth corner of the spawn area

    private GameObject spawnedObject;

    public int maxObjectCount;

   
    void Start()
    {
        spawnTimer = 0;
       
     
    }

    void Update()
    {
       
    }

    public void collectibleSpawning()
    {
       

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval && objectCount < maxObjectCount)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(Mathf.Min(spawnCorner1.x, spawnCorner2.x, spawnCorner3.x, spawnCorner4.x),
                                                              Mathf.Max(spawnCorner1.x, spawnCorner2.x, spawnCorner3.x, spawnCorner4.x)),
                                                Random.Range(Mathf.Min(spawnCorner1.y, spawnCorner2.y, spawnCorner3.y, spawnCorner4.y),
                                                              Mathf.Max(spawnCorner1.y, spawnCorner2.y, spawnCorner3.y, spawnCorner4.y)),
                                                Random.Range(Mathf.Min(spawnCorner1.z, spawnCorner2.z, spawnCorner3.z, spawnCorner4.z),
                                                              Mathf.Max(spawnCorner1.z, spawnCorner2.z, spawnCorner3.z, spawnCorner4.z)));
            spawnedObject = Instantiate(objectToSpawn[0], spawnPosition + spawnPositionOffset, Quaternion.identity);
            objectCount++;
            Destroy(spawnedObject, 12f);
            spawnTimer = 0;
        }
    
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        

    }



}

