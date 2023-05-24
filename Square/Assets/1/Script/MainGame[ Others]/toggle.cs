using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggle : MonoBehaviour
{
    [Header("TESTING CONTROLLER")]
    private CircleCollider2D Circle;
    private void Start()
    {
        Circle = GetComponent<CircleCollider2D>();
    }

    public void collder()
    {
        if (Circle.enabled)
        {
            Circle.enabled = false;
        }
        else
        {
            Circle.enabled = true;
        }

    }

}
