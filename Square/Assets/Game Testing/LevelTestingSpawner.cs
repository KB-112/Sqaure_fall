using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelTestingSpawner : MonoBehaviour
{
    public List<GameObject> gameObjects;   
    public float interval = 1f;
    private int currentIndex = 0;
    private int iterations = 0;
    public Vector3 spawnPositionOffset;
    GameObject spawnedObject;
    [SerializeField] private float destroyInstant;



    public void Start()
    {
        StartCoroutine(InstantiateGameObjects());

    }
    private IEnumerator InstantiateGameObjects()
    {
        while (true)  // This will keep spawning objects indefinitely
        {
            Vector3 spawnPosition = transform.position + spawnPositionOffset;
            spawnedObject = Instantiate(gameObjects[currentIndex], spawnPosition, Quaternion.identity);
            currentIndex = (currentIndex + 1) % gameObjects.Count;
            iterations++;
            if (iterations % 3 == 0)
            {
                gameObjects.Shuffle();
            }
            if (iterations < 2)
            {
                DontDestroyOnLoad(spawnedObject);
            }
            yield return new WaitForSeconds(interval);
            Destroy(spawnedObject, 10);
        }       

    }


   


   
}
