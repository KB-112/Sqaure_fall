using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectible : MonoBehaviour
{
    [Header("DEFAULT VALUES")]
    [SerializeField] private float spawnTimer;
    [SerializeField] private int objectCount;
    private GameObject spawnedObject;

    [Header("USER INPUTS")]
    public float spawnInterval = 9f;
    public GameObject[] objectToSpawn;
    [Header("SPAWN COORDINATES")]
    public Vector2 spawnCorner1; // First corner of the spawn area
    public Vector2 spawnCorner2; // Second corner of the spawn area
    public Vector2 spawnCorner3; // Third corner of the spawn area
    public Vector2 spawnCorner4; // Fourth corner of the spawn area

    public TargetSb targetSb;

    //----------------------------------------------//

  


    void Start()
    {
        objectCount = 0;

    }

    void Update()
    {
        collectibleSpawning();
    }

    public void collectibleSpawning()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            if ((objectCount % 5) == 0 && objectCount % 10 != 0 && objectCount != 0)
            {
                int a, b, c;
                a = objectCount;
                b = objectCount + 5;
                c = Random.Range(a, b);

                if (a < c && c < b || a == c || b == c)
                {
                    Debug.Log(c);
                    Vector2 spawnPosition = new Vector3(Random.Range(
                        Mathf.Min(spawnCorner1.x, spawnCorner2.x, spawnCorner3.x, spawnCorner4.x),
                        Mathf.Max(spawnCorner1.x, spawnCorner2.x, spawnCorner3.x, spawnCorner4.x)),
                        Random.Range(
                            Mathf.Min(spawnCorner1.y, spawnCorner2.y, spawnCorner3.y, spawnCorner4.y),
                            Mathf.Max(spawnCorner1.y, spawnCorner2.y, spawnCorner3.y, spawnCorner4.y)));

                    // Check for overlapping objects
                    int layerMask = 1 << LayerMask.NameToLayer("Obstacles");
                    Collider2D[] colliders = Physics2D.OverlapBoxAll(spawnPosition, objectToSpawn[0].GetComponent<Renderer>().bounds.size, 0);
                    if (colliders.Length == 0)
                    {
                        spawnedObject = Instantiate(objectToSpawn[0], spawnPosition, Quaternion.identity);
                      
                    }


                }

                Collider2D _collider = Physics2D.OverlapArea(targetSb.rightCorner, targetSb.leftCorner);

                if (_collider != null)
                {
                    Destroy(spawnedObject);
                }


            }
            objectCount++;
            spawnTimer = 0;
        }

       


    }


}







