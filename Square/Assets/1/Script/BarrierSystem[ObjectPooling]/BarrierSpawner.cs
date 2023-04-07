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
    [SerializeField] private float delayTimer;


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

                GameObject obj = pooledObjects[i];
                obj.SetActive(true);
                // move the object to the end of the list to change its order
                pooledObjects.RemoveAt(i);
                 pooledObjects.Add(obj);
              
                //ReturnObject(pooledObjects[i]);
                return pooledObjects[i];
            }

          



        }
       
        return null;


        
    }

    public void SetTimer(float time)
    {
        delayTimer = time;
    }

    public void ReturnObject(GameObject obj)
    {
        StartCoroutine(DisableAfterDelay(obj, delayTimer));
    }

    IEnumerator DisableAfterDelay(GameObject obj, float delay)
    { 
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
        pooledObjects.Add(obj);
    }
   







}
