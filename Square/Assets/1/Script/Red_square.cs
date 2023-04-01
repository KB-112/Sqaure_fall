using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_square : MonoBehaviour
{
    //Spwaning

    public GameObject[] objectToSpawn;
    public float spawnInterval = 0f;
    public Vector3 spawnPositionOffset;


    private   GameObject spawnedObject;

    //Spwan Motion Effects
    public float rotationSpeed = 50.0f;


    //Spwan Destroy
    private float sizeDecreaseAmount = 0.5f
       , sizeDecreaseDuration = 0.8f, t;


    public float originalSize, targetSize,delaySize = 7.0f;

    public GameObject Ball;
    float elapsedTime;


    GameObject a ;
    bool success = false;

    GameObject objs;

    void Start()
    {

      
        StartCoroutine(SpawnObject());
       



    }

    IEnumerator SpawnObject()                                                           //<--------Spawn Calling Controller
    {


       // int spawnCounter = 0;
        while (true)
        {
            Vector3 spawnPosition = transform.position + spawnPositionOffset;
            spawnedObject = Instantiate(objectToSpawn[0], spawnPosition, Quaternion.identity);
            spawnedObject.transform.rotation = Quaternion.Euler(0, 0, -90);


            if (success)
            {
               a = spawnedObject;
            }


            StartCoroutine(RotateObject(spawnedObject));
            // StartCoroutine(DecreaseSizeCoroutine(spawnedObject));
            //StartCoroutine(DestroySquare(spawnedObject));
          
           // spawnCounter++;

           /* 
            if (spawnCounter % 4 == 0) // check if the counter is a multiple of 4
            {
                yield return new WaitForSeconds(5f); // add a delay before spawning the next object
            }
           */
            yield return new WaitForSeconds(spawnInterval);


        }
    }

  

   public IEnumerator DestroySquare(GameObject obj)
    {
        while (true)
        {
            // destroy the spawned object after a delay

            //--------->size decrease


            //---------->Destroy & Stop Coroutines
            yield return new WaitForSeconds(13f);


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


   public  IEnumerator DecreaseSizeCoroutine(GameObject obj)
    {
        yield return new WaitForSecondsRealtime(delaySize);

        originalSize = transform.localScale.x;
        originalSize = 0.5f;
         targetSize = originalSize - sizeDecreaseAmount;
       elapsedTime = 0f;

        while (elapsedTime < sizeDecreaseDuration)
        {
            elapsedTime += Time.deltaTime;
            t = Mathf.Clamp01(elapsedTime / sizeDecreaseDuration);

            if (obj != null && obj.activeSelf) // check if the object is still active
            {
                obj.transform.localScale = Vector3.one * Mathf.Lerp(originalSize, targetSize, t);
            }
            else
            {
                break; // exit the loop if the object has been destroyed
            }

            yield return null;
        }
    }

   public  IEnumerator DestroySquarse()
    {
        while (true)
        {  success = !false;
            objs = a;
            yield return new WaitForSeconds(1f);
            Destroy(objs);
        }
    }


    
}


