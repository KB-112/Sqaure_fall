using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public float speed = 2f;
    public Transform startPoint;
    public Transform endPoint;
    public float sizeIncreaseAmount = 0.8f;
    public float sizeIncreaseDuration = 0.5f;

    private float startTime;
    private float journeyLength;

    private void Awake()
    {
        startTime = Time.time;
        StartCoroutine(IncreaseSizeCoroutine());
        journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
    }
    private IEnumerator IncreaseSizeCoroutine()
    {
        float originalSize = transform.localScale.x;
        float targetSize = originalSize + sizeIncreaseAmount;
        float elapsedTime = 0f;

        while (elapsedTime < sizeIncreaseDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / sizeIncreaseDuration);
            transform.localScale = Vector3.one * Mathf.Lerp(originalSize, targetSize, t);
            yield return null;
        }
    }


    private void Update()
    {
        float timeElapsed = Time.time - startTime;
        float distanceCovered = timeElapsed * speed;

        // Calculate the fraction of the journey completed using the ping-pong function
        float fractionOfJourney = Mathf.PingPong(distanceCovered, journeyLength) / journeyLength;

        // Move the ball along the journey using the lerp function
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, fractionOfJourney);
    }
}
