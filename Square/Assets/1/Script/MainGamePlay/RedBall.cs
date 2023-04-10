using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class RedBall : MonoBehaviour
{
    public int multiplier = 1;
    public float timeTracker = 0f;
    public float startPosition;


  [SerializeField]  private float storedposition;

    private float t;
    public Red_square rSquare;
    public points score;
    public GameObject rball;
    public GameObject Score_text;

    public DestroyParticleSystem destroyparticleSystem;

    public Renderer objectToFade;



    public bool stopball = false;

    public ObstaclesController[] obstaclesControllers;

    public CameraMOvement cameraMOvement;
    public SoundSystem soundController;

    public float sizeIncreaseAmount
    , sizeIncreaseDuration;

    public SpriteRenderer barPathSize;
    public GameObject bar;

    public float travelDuration;
    bool check = false;
    void Start()
    {



        StartCoroutine(IncreaseSizeCoroutine());

        barPathSize.size = new Vector2(2 * Math.Abs(startPosition - 0.25f - transform.localScale.x / 2), 0.58f);
        bar.transform.position = new Vector2(0, -startPosition);

    }

    // Update is called once per frame
    private void Update()
    {
        if (stopball)
            return;


      



    
        if (Input.GetMouseButtonDown(0))
        {
            multiplier *= -1;
            check = true;
          
            BallMovement();


            travelDuration = 1.3f;




            soundController.move();


        }
        else
        {check = false;
            travelDuration = 1.3f;
            BallMovement();
        }

    }

    public void BallMovement()
    {
       
        timeTracker += Time.deltaTime * multiplier * (1 / travelDuration);


        timeTracker = Mathf.Clamp01(timeTracker);
        if (check)
        {
            storedposition = 1 / storedposition;
            Debug.Log(storedposition);
            storedposition = Mathf.Lerp(startPosition, -startPosition, timeTracker);
        }
        else if (!check)
        {
            storedposition = Mathf.Lerp(startPosition, -startPosition, timeTracker);
        }
        transform.position = new Vector2(storedposition, -startPosition);


        if (timeTracker == 1)
        {

            multiplier *= -1;
             soundController.rebound();
        }

        else if (timeTracker == 0)
        {

            multiplier *= -1;
            soundController.rebound();
        }





    }




   


    
       
       



    private IEnumerator IncreaseSizeCoroutine()
    {


        float originalSize = transform.localScale.x;


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


                for (int i = 0; i < obstaclesControllers.Length; i++)
                {
                    obstaclesControllers[i].shouldMove = true;
                }


                SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = false;
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



}
