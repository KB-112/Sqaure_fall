using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawnBehaviour : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public float interval = 1f;
    private int currentIndex = 0;
    private int iterations = 0;
    public Vector3 spawnPositionOffset;


    public RedBall redBall;

    GameObject spawnedObject;
    [SerializeField] private float destroyInstant;
    private void Start()
    {
        StartCoroutine(InstantiateGameObjects());
    }
    public void Update()
    {

        if (redBall.stopball)
        {
            destroyInstant = 0f;
            Destroy(spawnedObject, destroyInstant);

            return;
        }
        if (!redBall.stopball)
        {
            destroyInstant = 11f;
            Destroy(spawnedObject, destroyInstant);
        }
    }
    private IEnumerator InstantiateGameObjects()
    {
        while (true)
        {

            Vector3 spawnPosition = transform.position + spawnPositionOffset;
            spawnedObject = Instantiate(gameObjects[currentIndex], transform.position, Quaternion.identity);
            currentIndex = (currentIndex + 1) % gameObjects.Count;

            iterations++;
            if (iterations % 3 == 0)
            {
                gameObjects.Shuffle();
            }
            spawnedObject.SetActive(false);
            yield return new WaitForSeconds(interval);

            spawnedObject.SetActive(true);



        }

    }
    private IEnumerator DestroyBall()
    {
        yield return new WaitForSeconds(8f);
        Destroy(spawnedObject, destroyInstant);
    }

}


