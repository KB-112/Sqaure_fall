using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChange : MonoBehaviour
{


  
    void Start()

    {
        Vector2 raycastDirection = Vector2.down; // cast the ray downwards
        float raycastDistance = 1.0f; // set the distance of the ray
        LayerMask layerMask = LayerMask.GetMask("Obstacles"); // specify the layer you want to detect collisions with
        RaycastHit2D hit = Physics2D.Raycast(transform.position, raycastDirection, raycastDistance, layerMask);

        if (hit.collider != null)
        {
            // A collision with the specified layer was detected, do something here
            Debug.Log("Hit object on layer " + LayerMask.LayerToName(hit.collider.gameObject.layer));
        }

        float moveAmount = 0.5f; // set the amount to move
        transform.position = new Vector2(transform.position.x, transform.position.y + moveAmount);
    }


}
    
