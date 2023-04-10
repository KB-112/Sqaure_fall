using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSb : MonoBehaviour
{

    [Header("SCREEN BOUNDS CONSTRAINTS")]  //collision detection i.e collectibles or obstacles
    public Vector2 rightCorner;
    public Vector2 leftCorner;
   
    private void OnDrawGizmos()
    {
        ScreenBounds.DrawRectange(rightCorner,leftCorner);
    }
}
