using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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

   
    void Start()
    {
        elapsedTime = 0;
        StartCoroutine(IncreaseSizeCoroutine());

        currentStartPos = startPos;
        currentEndPos = endPos;

        destroyParticlesystem.Stop();
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
          

            if (t >= 1) // if the ball has reached the end position, toggle the moving_right flag to move left
            { 
                moving = false;
                elapsedTime = 0;
               
               
            }
        }
        else // if the ball is currently moving left
        {
            transform.position = Vector3.Lerp(currentStartPos, currentEndPos, t);


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
        duration = 1.8f;
        yield return new WaitForSeconds(0.2f);
        {
            duration = 0.8f;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("blackSquare"))
        {
            destroyParticlesystem.Play();
            Destroy(this.gameObject);

        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("redSquare"))
        {
          
            point.IncrementScore();
        }
    }
}
