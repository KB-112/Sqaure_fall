using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSquare : MonoBehaviour
{
   //Spwaning

    public GameObject[] objectToSpawn;  
    public float spawnInterval = 0f;   
    public Vector3 spawnPositionOffset;


    private GameObject spawnedObject;

    //Spwan Motion Effects
    public float rotationSpeed = 50.0f;


    //Spwan Destroy
    private float sizeDecreaseAmount = 0.5f
       , sizeDecreaseDuration = 0.8f, t;

 
    public float delaySize = 7.0f;

    public GameObject Ball;



    void Start()
    {
        StartCoroutine(SpawnObject());

       


      
    }

    IEnumerator SpawnObject()                                                           //<--------Spawn Calling Controller
    {

        int spawnCounter = 0;
        while (true)
        {
            Vector3 spawnPosition = transform.position + spawnPositionOffset;
            spawnedObject = Instantiate(objectToSpawn[0], spawnPosition, Quaternion.identity);
            spawnedObject.transform.rotation = Quaternion.Euler(0, 0, -90);



            StartCoroutine(RotateObject(spawnedObject));
            StartCoroutine(DecreaseSizeCoroutine(spawnedObject));
            StartCoroutine(DestroySquare(spawnedObject));
            spawnCounter++;

            if (spawnCounter % 4 == 0) // check if the counter is a multiple of 4
            {
                yield return new WaitForSeconds(5f); // add a delay before spawning the next object
            }

            yield return new WaitForSeconds(spawnInterval);
            

        }
    }

    IEnumerator DestroySquare(GameObject obj)
    { while (true)
        {
            // destroy the spawned object after a delay

            //--------->size decrease
            

            //---------->Destroy & Stop Coroutines
            yield return new WaitForSeconds(9f);


            StopCoroutine(RotateObject(spawnedObject));
            StopCoroutine(DecreaseSizeCoroutine(spawnedObject));      
            
            Destroy(obj);
        }
    }

    IEnumerator RotateObject(GameObject obj)                                             //<--------Spawn Roatation Controller
    {
        while (obj != null && obj.activeSelf) // check if the object is still active
        {
            obj.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            yield return null;
        }
        Debug.Log("Destroyed - Not accessible");
    }

    void OnDrawGizmosSelected()                                                            //<--------Spawn Location On Unity Editor
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + spawnPositionOffset, 0.1f);
    }


    private IEnumerator DecreaseSizeCoroutine(GameObject obj)                                 //<--------Spawn Size controller while destroying
    { yield return new WaitForSeconds(delaySize);
        
        float originalSize = transform.localScale.x;
        originalSize = 0.5f;
        float targetSize = originalSize -sizeDecreaseAmount;
        float elapsedTime = 0f;

        while (elapsedTime < sizeDecreaseDuration)
        {
            elapsedTime += Time.deltaTime;
            t = Mathf.Clamp01(elapsedTime / sizeDecreaseDuration);
            obj.transform.localScale = Vector3.one * Mathf.Lerp(originalSize, targetSize, t);
            yield return null;
        }

       
    }
}

