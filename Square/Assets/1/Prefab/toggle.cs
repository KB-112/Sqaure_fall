using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggle : MonoBehaviour
{
    private BoxCollider2D box;



    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    public void collder()
    {
        if (box.enabled)
        {
            box.enabled = false;
        }
        else
        {
            box.enabled = true;
        }

    }

}
