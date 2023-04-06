


using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(PrefabAssetType))]

public class BarrierCall : MonoBehaviour
{
    [Header("Spawningcontroller")]
    [SerializeField] private float spawnTimer;
    [SerializeField] private GameObject[] objectToSpawn;
    [SerializeField] private int spawnInterval;
    [SerializeField] private Vector3 spawnPositionOffset;
    private int objectCount;
    [SerializeField] private float delaytimer;
    [SerializeField] private int delayInterval;

    void Start()
    {
        spawnTimer = 0;
        objectCount = 0;

    }
    public void Update()
    {
        spawnTimer += Time.deltaTime;
        delaytimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            Vector3 spawnPosition = transform.position + spawnPositionOffset;
           


            
            GameObject spawnedObject = objectToSpawn[0];
           
            spawnedObject = BarrierSpawner.SharedInstance.GetPooledObject();




              



                if (spawnedObject != null)
                {


                    spawnedObject.SetActive(true);
                    spawnedObject.transform.position = spawnPosition;
                    Debug.Log("Call success");


                }



                objectCount++;
                if (delaytimer >= delayInterval )
                {
                    BarrierSpawner.SharedInstance.ReturnObject(spawnedObject);
                }

                spawnTimer = 0;

            
        }
    }
}
