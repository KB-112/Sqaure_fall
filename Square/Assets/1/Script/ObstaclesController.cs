using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public float duration;
    private float elapsedTime;
   

    private float t;

    private Vector3 currentStartPos;
    private Vector3 currentEndPos;

    private bool moving = true;

  

    void Start()
    {
        elapsedTime = 0;
     

        currentStartPos = startPos;
        currentEndPos = endPos;

        StartCoroutine(SpawnObject());
    }

    public void Update()
    {
        float t = elapsedTime / duration;

        if (moving) // if the ball is currently moving right
        {
            transform.position = Vector3.Lerp(currentStartPos, currentEndPos, t);

            if (t >= 1) // if the ball has reached the end position, toggle the moving_right flag to move left
            {
                moving = false;
                elapsedTime = 0;
            }
        }

        elapsedTime += Time.deltaTime;

      
        
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return null;  // don't do anything in this coroutine
        }
    }
}
