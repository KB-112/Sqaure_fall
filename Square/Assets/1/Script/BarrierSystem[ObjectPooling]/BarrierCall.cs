


using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

//[RequireComponent(typeof(PrefabAssetType))]

public class BarrierCall : MonoBehaviour
{
    [Header("Spawningcontroller")]
    [SerializeField] private float spawnTimer,t;
   
    [SerializeField] private int spawnInterval;
    [SerializeField] private Vector3 spawnPositionOffset;
    private int objectCount;
 
    [SerializeField] private int delayInterval;
    bool delayed = false;

    private GameObject spawnedObject;


    void Start()
    {
        spawnTimer = 0;
        objectCount = 0;
        t = 0;
       
    }
    public void FixedUpdate()
    {
        spawnTimer += Time.deltaTime;
       
        
        if (spawnTimer >= spawnInterval)
        {
            Vector3 spawnPosition = transform.position + spawnPositionOffset;

          

            spawnedObject = BarrierSpawner.SharedInstance.GetPooledObject();


            if (spawnedObject != null)
            {

              
                spawnedObject.transform.position = spawnPosition;

                spawnedObject.SetActive(true);


            }


           

            objectCount++;



          
            spawnTimer = 0;
            
        }
    }
   
     
        

   

}

