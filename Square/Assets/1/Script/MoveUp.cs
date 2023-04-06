using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{ //-------------------------------------------------//
    public float speed = 5f; // speed of upward movement
    private Rigidbody2D rb; // reference to the object's Rigidbody2D component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // get reference to Rigidbody2D component
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, speed); // set the object's velocity to move upwards at a constant speed
    }
}
