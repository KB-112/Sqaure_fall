using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_square : MonoBehaviour
{
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("blackSqaure"))
        {
          
            Debug.Log("Destroy");

        }
    }
}
