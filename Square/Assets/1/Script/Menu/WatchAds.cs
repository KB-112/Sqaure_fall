using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchAds : MonoBehaviour
{
    public float startTime = 3f; // Initial time value
    public float timerSpeed = 1f; // Speed at which the timer runs
    public Image timerImage; // Reference to the UI filled horizontal image
    public Button skipButton; // Reference to the skip button

   [HideInInspector] public bool isTimerRunning = true;

    private void Start()
    {
        // Set the initial fill amount of the image to 1 (full)
        timerImage.fillAmount = 1f;

        // Attach the skip function to the button's onClick event
        skipButton.onClick.AddListener(SkipTimer);

        // Start the timer coroutine
        StartCoroutine(RunTimer());
    }

    private IEnumerator RunTimer()
    {
        float currentTime = startTime;

        while (currentTime > 0f)
        {
            if (isTimerRunning)
            {
                currentTime -= Time.deltaTime * timerSpeed;
                timerImage.fillAmount = currentTime / startTime;
            }
            yield return null;
        }
       
        // Timer has reached zero
        Debug.Log("Timer has ended!");
    }

    public void SkipTimer()
    {
        isTimerRunning = false;
        timerImage.fillAmount = 0f;
        Debug.Log("Timer has been skipped!");
    }
}


