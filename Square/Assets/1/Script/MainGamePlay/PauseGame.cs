using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject PauseMenu;
    bool unpause = false;

    public float startTime = 5f; // Initial time value
    public float timerSpeed = 1f; // Speed at which the timer runs
    public Image timerImage; // Reference to the UI filled horizontal image
    [HideInInspector] public bool isTimerRunning = false;

    public Button Quitbtn;

    private void Start()
    {
        timerImage.fillAmount = startTime;
        StartCoroutine(RunTimer());
        Quitbtn.onClick.AddListener(SkipTimer);
    }

    public void PauseScreen()
    {
        Time.timeScale = 0f;
        isTimerRunning = true;
        PauseMenu.SetActive(true);
      
    }

    public void UnpauseScreen()
    {
        isTimerRunning = false;
        PauseMenu.SetActive(false);
       
        Time.timeScale = 1f; // Set the time scale back to normal (1) when unpausing.
    }

    private IEnumerator RunTimer()
    {
        float currentTime = startTime;

        while (currentTime > 0f)
        {
            if (isTimerRunning)
            {
                currentTime -= Time.unscaledDeltaTime * timerSpeed; // Use Time.unscaledDeltaTime instead of Time.deltaTime
                timerImage.fillAmount = currentTime / startTime;
            }

            yield return null;
        }

        // Timer has finished, perform any actions you need here.
        if (InterstialAdss.interstitialAd != null && InterstialAdss.interstitialAd.CanShowAd())
        {
            StartCoroutine(A());

            InterstialAdss.interstitialAd.OnAdFullScreenContentClosed += () =>
            {

                UnpauseScreen();



            };
        }


       
        
    }
    public void SkipTimer()
    {
        isTimerRunning = false;
        timerImage.fillAmount = 0f;
        UnpauseScreen();
        Debug.Log("Timer has been skipped!");



    }

    IEnumerator A()
    {
        yield return null;
        InterstialAdss.instance.ShowAd();
    }
}
