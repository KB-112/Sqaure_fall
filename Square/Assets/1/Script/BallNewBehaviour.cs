using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallNewBehaviour : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    public float duration;
    private float elapsedTime;

    private float sizeIncreaseAmount = 0.8f
        , sizeIncreaseDuration = 0.8f, t;


    private Vector3 currentStartPos;
    private Vector3 currentEndPos;

    private bool moving = true;











    public bool particle = false;



    public Red_square rSquare;

    public DestroyParticleSystem destroyParticleSysteml;

    public points score;



    void Start()
    {
        rSquare = GetComponent<Red_square>();


        elapsedTime = 0;
        StartCoroutine(IncreaseSizeCoroutine());

        currentStartPos = startPos;
        currentEndPos = endPos;



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
    public void Update()
    {
        float t = elapsedTime / duration;

        if (moving) // if the ball is currently moving right
        {
           
            transform.position = Vector3.Lerp(currentEndPos, currentStartPos, t);

            if (t >= 1 ) // if the ball has reached the end position, toggle the moving_right flag to move left
            {
                moving = false;
                elapsedTime = 0;


            }
        }
        else // if the ball is currently moving left
        {
            transform.position = Vector3.Lerp(currentStartPos, currentEndPos, t);


           

            if (t >= 1 ) // if the ball has reached the start position, toggle the moving_right flag to move right
            {
                moving = true;
                elapsedTime = 0;
            }
        }

        elapsedTime += Time.deltaTime;
    }





    public void MoveLeft()
    {
        if (moving && Vector3.Distance(transform.position, currentStartPos) < 1f) // if the ball is close to the start position while moving right
        {
            currentEndPos = transform.position; // set the current end position to the current position of the ball
            currentStartPos = endPos; // set the current start position to the end position

            moving = false;
            elapsedTime = 0;
            StartCoroutine(speed());
        }
        else if (!moving) // if the ball is already moving towards the end point
        {
            currentStartPos = transform.position; // set the current start position to the current position of the ball
            currentEndPos = endPos; // set the current end position to the end position

            moving = true;
            elapsedTime = 0;
            StartCoroutine(speed());
        }
    }


    public void MoveRight()
    {
        if (!moving && Vector3.Distance(transform.position, currentEndPos) < 0.5f) // if the ball is close to the end position while moving left
        {
            currentStartPos = transform.position; // set the current start position to the current position of the ball
            currentEndPos = startPos; // set the current end position to the start position

            moving = true;
            elapsedTime = 0;
            StartCoroutine(speed());
        }
        else if (moving) // if the ball is already moving towards the start point
        {
            currentEndPos = transform.position; // set the current end position to the current position of the ball
            currentStartPos = startPos; // set the current start position to the start position

            moving = false;
            elapsedTime = 0;
            StartCoroutine(speed());
        }



    }


        IEnumerator speed()
    {
        duration = 1f;
        yield return new WaitForSeconds(0.2f);
        {
            duration = 1f;
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("redSquare"))
        {
            score.IncrementScore();
            //rSquare.StartCoroutine(rSquare.DestroySquarse());




        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {
            destroyParticleSysteml.UnpauseParticleSystem();

            Destroy(this.gameObject);



        }

    }
}
