using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PositionChange : MonoBehaviour
{

    public float speed = 1f;
    private float originalY,targetY;

    void Start()
    {
        originalY = transform.position.y;
    }

    void Update()
    {
        float newY = Mathf.Lerp(originalY, targetY, speed * Time.deltaTime);

        transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
    }

}

