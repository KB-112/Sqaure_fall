using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChange : MonoBehaviour
{
    // Set the layers that should be checked for overlapping
    public LayerMask overlappingLayers;

    // The distance that should be checked for overlapping
    public float overlapDistance = 0.1f;

    // The new position to move the overlapping object to
    public Vector3 newPosition;

    void Update()
    {
        // Check if the object is overlapping with any other objects on the specified layers
        Collider[] colliders = Physics.OverlapSphere(transform.position, overlapDistance, overlappingLayers);

        if(colliders.Length > 0)

        {
            // Move the object to the new position
            transform.position = newPosition;

            Debug.Log("Object moved to new position due to overlapping.");
        }


    else
        {
            Debug.Log("No overlapping detected.");
        }


    }



}

