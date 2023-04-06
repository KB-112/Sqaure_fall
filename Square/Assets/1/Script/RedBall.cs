using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RedBall : MonoBehaviour
{
    public int multiplier = 1;              // Used to change the speed and direction of the object's movement
    public float timeTracker = 0f;          // Keeps track of the object's position along its path
    public Vector2 startPosition;           // The starting position of the object
    public Vector2 endPosition;             // The end position of the object
    private float t;
    public Red_square rSquare;
    public points score;
    public GameObject rball;
    public GameObject Score_text;

    public DestroyParticleSystem destroyparticleSystem;

    public Renderer objectToFade;
    public float fadeRate;


    public bool stopball = false;

    public ObstaclesController[] obstaclesControllers;

    public CameraMOvement cameraMOvement;
    public SoundSystem soundController;
    void Start()
    {

  
        StartCoroutine(IncreaseSizeCoroutine(0.44f, 0.44f));
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (stopball)
            return;
     
        if (Input.GetMouseButtonDown(0))
        {
            multiplier *= -1;
            

            BallMovement(0.92f);
            soundController.move();

        }
        else
        {
            BallMovement(1.2f);
        }
    }

    public void BallMovement(float travelDuration)
    {
        // Increment timeTracker based on the current multiplier, the inverse of travelDuration, and the time elapsed since the last frame
        timeTracker += Time.deltaTime * multiplier * (1 / travelDuration);

        // Clamp timeTracker value between 0 and 1 to ensure that the object stays within the bounds of its path
        timeTracker = Mathf.Clamp01(timeTracker);

        // Set the position of the object using Vector2.Lerp to interpolate its position between the start and end position based on timeTracker
        transform.position = Vector2.Lerp(startPosition, endPosition, timeTracker);

        // If the object has reached the end of its path, invert the multiplier to change the direction of its movement
        if (timeTracker == 1)
        {
         
            multiplier *= -1;
            soundController.rebound();
        }
        // If the object has reached the starting point, reset timeTracker to zero
        else if (timeTracker == 0)
        {
          
            multiplier *= -1;
            soundController.rebound();
        }

       
        


    }

    private IEnumerator IncreaseSizeCoroutine(float sizeIncreaseAmount
    , float sizeIncreaseDuration)
    {


        float originalSize= transform.localScale.x;
        

        float targetSize = originalSize + sizeIncreaseAmount;
        float elapsedTime = 0f;

        while (elapsedTime < sizeIncreaseDuration)
        {
            elapsedTime += Time.deltaTime;
            t = Mathf.Clamp01(elapsedTime / sizeIncreaseDuration);
            transform.localScale = Vector3.one * Mathf.Lerp(originalSize, targetSize, t);
            yield return null;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("redSquare"))
        {
            score.UpdateScore();
            Destroy(collision.gameObject);
            soundController.point();
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {

            Debug.Log("destroy happen");


            soundController.explode();
            if (collision.gameObject)
            {
               
                stopball = true;

                
                for(int i = 0; i < obstaclesControllers.Length; i++)
                {
                    obstaclesControllers[i].shouldMove = true;
                }
                StartCoroutine(FadeObject());
               // CircleCollider2D collider = gameObject.GetComponent<CircleCollider2D>();
                //collider.enabled = false;

                BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();  
                collider.enabled = false;
               
                destroyparticleSystem.UnpauseParticleSystem();
                
                StartCoroutine(DestroyDelay());
                
            }


    


           
        }

    }

    IEnumerator DestroyDelay()
    {

        yield return new WaitForSecondsRealtime(0.5f);

        Debug.Log("Flag initiation Successfull");

        destroyparticleSystem.NonActive();
        yield return new WaitForSecondsRealtime(0.5f);
        cameraMOvement.ball_collision_successful = true;


    }

    IEnumerator FadeObject()
    {
        // Loop until the alpha value reaches 0
        while (objectToFade.material.color.a > 0)
        {
            // Get the current color of the material
            Color currentColor = objectToFade.material.color;

            // Calculate the new alpha value
            float newAlpha = currentColor.a - (fadeRate * Time.unscaledDeltaTime);

            // Create a new color with the new alpha value
            Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);

            // Set the new color to the material
            objectToFade.material.color = newColor;

            // Wait for the next frame
            yield return null;
        }

        // Deactivate the object when the alpha value reaches 0

    }


}
