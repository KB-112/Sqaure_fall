using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMOvement : MonoBehaviour
{
    private Vector2 startPosition;
    private Vector2 targetPosition;

    [Header("CAMERA CONTROL")]
    [SerializeField] public float distanceToMove = 5.0f;
    [SerializeField] public float speed = 2.0f;

    public bool ball_collision_successful = false;  // Boolean value passed in Redball for detection of the collision and restart screen appears 
    public GameObject[] Restart_panel;
    public GameObject highscoreText;
    void Start()
    {
      highscoreText.SetActive(false);
      startPosition = transform.position;
      targetPosition = startPosition + new Vector2(0f, distanceToMove);
      Restart_panel[0].SetActive(false);
        
    }

    public void Update()
    {
        if (ball_collision_successful)
         {
            highscoreText.SetActive (true);
            float step = speed * Time.unscaledDeltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
            Restart_panel[0].SetActive(true);
            Restart_panel[1].SetActive(true);
        }
    }

    
}
    

