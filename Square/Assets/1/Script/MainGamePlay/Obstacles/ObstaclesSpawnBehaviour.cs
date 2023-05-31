using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawnBehaviour : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public List<GameObject> Collectibles =new List<GameObject>();
    public float interval = 1f;
    private int currentIndex = 0;
    private int iterations = 0;
    public Vector3 spawnPositionOffset;


    public RedBall redBall;

    GameObject spawnedObject;
    [SerializeField] private float destroyInstant;


   
    

    GameObject obj;

    private void Start()
    {
        StartCoroutine(InstantiateGameObjects() );
       
       


    }
   
    private IEnumerator InstantiateGameObjects()
    {
        while (!redBall.stopball)
        {

            Vector3 spawnPosition = transform.position + spawnPositionOffset;
            CollectiblesIterationController();
            spawnedObject = Instantiate(gameObjects[currentIndex], transform.position, Quaternion.identity);
            currentIndex = (currentIndex + 1) % gameObjects.Count;

            iterations++;
            if (iterations % 3 == 0)
            {
                gameObjects.Shuffle();
            }
          
           
            yield return new WaitForSeconds(interval);

            

                Destroy(spawnedObject,12);
            
            

        }

    }
  

    public void CollectiblesIterationController()
    {
        
        if ((iterations % 5) == 0 && iterations % 10 != 0 && iterations != 0)
        {
            int a, b, c;
            a = iterations;
            b = iterations + 5;
            c = Random.Range(a, b);
            if (redBall.stopball)
            {



                return;
            }
            if (a < c && c < b || a == c || b == c )
            {
                Debug.Log("Square spawned");
              
                CollectibleSelection();
                
                 

                                       
            }
        }
    }


   
   public void CollectibleSelection()
    {
      
        int randomIndex = Random.Range(0, Collectibles.Count);
       
        obj = Instantiate(Collectibles[randomIndex]);
        obj.transform.SetParent(spawnedObject.transform);
        obj.SetActive(true);
            iterations++;
      
        
   }
    
}


