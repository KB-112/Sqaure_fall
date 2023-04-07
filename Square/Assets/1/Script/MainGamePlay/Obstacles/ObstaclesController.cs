using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
   
    private float elapsedTime;
   

    private float t;

    private Vector3 currentStartPos;
    private Vector3 currentEndPos;

    private bool moving = true;

 


   
   public float duration;

   public bool shouldMove = true;

    void Start()
    {
        if (!shouldMove) return;
        elapsedTime = 0;
     

        currentStartPos = startPos;
        currentEndPos = endPos;


       

    }
  
    public void Update()
    {
        if (!shouldMove) return;

        Player_stages_1();


    }
    
    

 public void Player_stages_1()
    {
     
            duration = 10f;


        if (!shouldMove)
        {
            elapsedTime = 0;
            return;
        }

        float t = elapsedTime / duration;

        if (moving) 
        {
            transform.position = Vector3.Lerp(currentStartPos, currentEndPos, t);

            if (t >= 1) 
            {
                moving = false;
                elapsedTime = 0;

             
            }


        }
        elapsedTime += Time.deltaTime;
    }


   

    
}
