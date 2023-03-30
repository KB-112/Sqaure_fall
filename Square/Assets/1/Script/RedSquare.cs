using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSquare : MonoBehaviour
{
    public GameObject prefab;
    public int numObjects;
    public float rotationSpeed;

    void Start()
    {
        // Spawn the objects
        for (int i = 0; i < numObjects; i++)
        {
            GameObject obj = Instantiate(prefab, transform.position, Quaternion.identity);
            // Set the parent of the spawned object to be this game object
            obj.transform.parent = transform;
            // Randomize the position of the spawned object within a radius of 1 unit
            obj.transform.localPosition = Random.insideUnitCircle;
        }
    }

    void Update()
    {
        // Rotate all child objects around the z-axis
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
        }
    }
}
