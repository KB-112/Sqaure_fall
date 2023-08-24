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
   public  bool playerdonothing = false;
    public Button quantspentbtn;
    float currentTime;

    public CameraMOvement cmmovement;
    private void Start()
    {
        timerImage.fillAmount = startTime;
        StartCoroutine(RunTimer());
        Quitbtn.onClick.AddListener(SkipTimer);
        quantspentbtn.onClick.AddListener(timeReset);
    }

    public void timeReset()
    {
        isTimerRunning = false;
        currentTime = startTime; // Reset currentTime to its initial value
        timerImage.fillAmount = currentTime / startTime; // Reset the UI fill amount
        UnpauseScreen();
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
        currentTime = startTime;

        while (currentTime > 0f)
        {
            if (isTimerRunning)
            {
                currentTime -= Time.unscaledDeltaTime * timerSpeed; // Use Time.unscaledDeltaTime instead of Time.deltaTime
                timerImage.fillAmount = currentTime / startTime;
            }

            yield return null;
        }
     
      cmmovement.timeover = true;//end game
        UnpauseScreen();
     
        if (InterstialAdss.interstitialAd != null && InterstialAdss.interstitialAd.CanShowAd())
        {
           
            StartCoroutine(A());
             //if player do nothing neither click any btn
        }


       
        
    }
    public void SkipTimer()  //quit btn
    {
       
        isTimerRunning = false;
        timerImage.fillAmount = 0f;      
        UnpauseScreen();
        
        Debug.Log("Timer has been skipped!");



    }

    IEnumerator A() // ads
    {
        yield return new WaitForSeconds(0);
        InterstialAdss.instance.ShowAd();
    }
}
