using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    private float elapsedTime;
    private Vector2 currentStartPos;
    private Vector2 currentEndPos;
    private bool moving = true;
    [Header("OBSTACLE SPAWN POSITION")]
    public Vector2 startPos;
    public Vector2 endPos;
    [SerializeField]  private float duration;
    public bool shouldMove = true;

    void Start()
    {
        if (!shouldMove) return;             //spawning stop after ball is destroyed
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
        float reservedTime = elapsedTime / duration;
        if (moving) 
        {
            transform.position = Vector2.Lerp(currentStartPos, currentEndPos, reservedTime);

            if (reservedTime >= 1) 
            {
                moving = false;
                elapsedTime = 0;
            }
        }
        elapsedTime += Time.deltaTime;
    }
  
    
}
