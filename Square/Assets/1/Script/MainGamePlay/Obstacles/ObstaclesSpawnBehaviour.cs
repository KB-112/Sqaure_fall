using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawnBehaviour : MonoBehaviour
{
  private float spawnTimer;
  [Header("USER INPUT")]
  public GameObject[] objectToSpawn;
  public float spawnInterval = 9f;
  public Vector3 spawnPositionOffset;
  public RedBall redBall;
  [SerializeField]private float destroyInstant ;

    void Start() { spawnTimer = 0; }
    
    public void Update()
    {
        if (redBall.stopball) return;

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            Vector3 spawnPosition = transform.position + spawnPositionOffset;
            int randomIndex = Random.Range(0, objectToSpawn.Length);
            GameObject spawnedObject = Instantiate(objectToSpawn[randomIndex], spawnPosition, Quaternion.identity);    
            if (redBall.stopball)
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


