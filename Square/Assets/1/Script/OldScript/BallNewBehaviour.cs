using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
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


    public int numDirectionChanges = 0;
    float i;

   
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
    void Update()
    {
        float t = elapsedTime / duration;

        if (moving)
        { // if the ball is currently moving right
            transform.position = Vector3.Lerp(startPos, endPos, t);

            if (t >= 1)
            { // if the ball has reached the end position, toggle the moving_right flag to move left
                moving = false;
                elapsedTime = 0;
            }
        }
        else
        { // if the ball is currently moving left
            transform.position = Vector3.Lerp(endPos, startPos, t);

            if (t >= 1)
            { // if the ball has reached the start position, toggle the moving_right flag to move right
                moving = true;
                elapsedTime = 0;
            }
        }

       
    

      if(Input.GetMouseButtonDown(0))
        {
            MoveLeft();
        }


        elapsedTime += Time.deltaTime;
    }


    public void MoveLeft()
    {
        elapsedTime = 0;

        // Swap the start and end positions to reverse the direction
        Vector3 temp = startPos;
        startPos = endPos;
        endPos = temp;

        moving = false;


        StartCoroutine(speed());
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
            //score.IncrementScore();
            //rSquare.StartCoroutine(rSquare.DestroySquarse());




        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {
          //  destroyParticleSysteml.UnpauseParticleSystem();

            Destroy(this.gameObject);



        }

    }
}
