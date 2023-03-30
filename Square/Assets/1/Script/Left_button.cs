using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Left_button : MonoBehaviour,IPointerClickHandler
{
   
    public BallBehaviour ball;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
       
        ball.MoveLeft();
    }


   
}
