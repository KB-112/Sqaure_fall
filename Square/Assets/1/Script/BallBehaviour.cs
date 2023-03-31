using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class BallBehaviour : MonoBehaviour
{
 
    public Vector3 startPos;
    public Vector3 endPos;
    public float duration;
    private float elapsedTime;
   
    private float sizeIncreaseAmount = 0.8f
        , sizeIncreaseDuration = 0.8f,t;


    private Vector3 currentStartPos;
    private Vector3 currentEndPos;

    private bool moving = true;



    public BoxCollider2D BoxCollider2D;
    public ParticleSystem destroyParticlesystem;

    public Score point;

    public SpriteRenderer ball;


    bool particle = false;


    public GameObject redSquare;
    public Red_square rSquare;


    
    void Start()
    {
        elapsedTime = 0;
        StartCoroutine(IncreaseSizeCoroutine());

        currentStartPos = startPos;
        currentEndPos = endPos;

        destroyParticlesystem.Stop();
        ball = GetComponent<SpriteRenderer>();
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
            transform.position = Vector3.Lerp(currentStartPos, currentEndPos, t);


            if (t >= 1) // if the ball has reached the end position, toggle the moving_right flag to move left
            { 
                moving = false;
                elapsedTime = 0;
               
               
            }
        }
        else // if the ball is currently moving left
        {
            transform.position = Vector3.Lerp(currentEndPos, currentStartPos, t);
          


            if (t >= 1) // if the ball has reached the start position, toggle the moving_right flag to move right
            {
                moving = true;
                elapsedTime = 0;
            }
        }

        elapsedTime += Time.deltaTime;
    }





    public void MoveLeft()
    {
        moving = false;
        elapsedTime = 0;
       StartCoroutine( speed());

    }

    public void MoveRight()
    {
        moving = true;
        elapsedTime = 0;

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


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("blackSquare"))
        {
            ball.color = new Color(1,1,1,0f);
            currentEndPos.x = 0;
            currentStartPos.x = 0;
             transform.position = Vector3.Lerp(currentEndPos, currentStartPos, t);

            destroyParticlesystem.Play();
           particle = true;
           
            StartCoroutine (DestroyDelay());

        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("redSquare"))
        {
          
           
            point.IncrementScore();
            rSquare.A();
        }
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(5f);
        {
            if (particle)
            {
               Destroy(this.gameObject);
               
               
            }
        }
    }
}
