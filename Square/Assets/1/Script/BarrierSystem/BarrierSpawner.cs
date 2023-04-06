using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class BarrierSpawner : MonoBehaviour
{
    public static BarrierSpawner SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject[] objectToPool;
    public int amountToPool;

    

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            int randomIndex = Random.Range(0, objectToPool.Length);
            tmp = Instantiate(objectToPool[randomIndex]);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }

       


    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                
                return pooledObjects[i];
            }



        }

       
       
        return null;


        
    }
    public void ReturnObject(GameObject obj)
    {
        for (int i = 0; i < amountToPool; i++)
        {
            obj = pooledObjects[i];
            obj.SetActive(false);
        }
    }


   

   
}
