using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMOvement : MonoBehaviour
{
    public float distanceToMove = 5.0f;
    public float speed = 2.0f;

    private Vector3 startPosition;
    private Vector3 targetPosition;



    public bool ball_collision_successful = false;

    void Start()
    {
      
        startPosition = transform.position;
        targetPosition = startPosition + new Vector3(0f, distanceToMove, 0.0f);

        
    }

    public void Update()
    {

        if (ball_collision_successful)
         {


            float step = speed * Time.unscaledDeltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
    }
}
    

