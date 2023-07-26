using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI timertext;

    private DateTime startTime;
    private TimeSpan elapsedTime;
    private bool isTimerRunning;

    string btn = "key";
    bool buttonState = false; // Initialize buttonState as false
    public Button ntn;
    private bool isApplicationPaused = false;

    [HideInInspector] public static bool doublescore =false;
    public void BtnPress()
    {
        PlayerPrefs.SetInt(btn, 1);
        PlayerPrefs.Save();
        ntn.interactable = false;
        buttonState = true; // Set buttonState to true after button press

        if (!isApplicationPaused)
        {
            LoadTimerState();
        }

        InitializeTime();
        StartCoroutine(UpdateTimerCoroutine());
    }

    public void Start()
    {
        if (PlayerPrefs.HasKey(btn) || !ntn.interactable)
        {
            buttonState = true;
            Debug.Log("Btn pressed");

            LoadTimerState();
            InitializeTime();
            StartCoroutine(UpdateTimerCoroutine());
        }
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (PlayerPrefs.HasKey(btn))
        {
            if (pauseStatus)
            {
                Debug.Log("Pause Executing excess");
                SaveTimerState();
                isApplicationPaused = true;
                StopTimer(); // Stop the timer when the application is paused
            }
            else
            {
                // Resume the timer when the application is resumed
                isApplicationPaused = false;
            
                StartCoroutine(UpdateTimerCoroutine());
            }
        }
    }

    private IEnumerator UpdateTimerCoroutine()
    {
        while (elapsedTime.TotalSeconds > 0)
        {
            if (!isApplicationPaused)
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                UpdateTimerText();
                doublescore = true;
            }
            yield return new WaitForSeconds(1f);
        }

        StopTimer();
        doublescore = false;
    }

    private void StopTimer()
    {
        isTimerRunning = false;
      
        UpdateTimerText(); // Ensure the timer text is updated when the timer stops
    }

    private void LoadTimerState()
    {
        string startTimeString = PlayerPrefs.GetString("startTime", "");
        startTime = !string.IsNullOrEmpty(startTimeString) ? DateTime.Parse(startTimeString) : DateTime.Now;

        string elapsedTimeString = PlayerPrefs.GetString("elapsedTime", "");
        elapsedTime = !string.IsNullOrEmpty(elapsedTimeString) ? TimeSpan.Parse(elapsedTimeString) : TimeSpan.FromMinutes(5);

        isTimerRunning = PlayerPrefs.GetInt("isTimerRunning", 0) == 1;
    }

    private void SaveTimerState()
    {
        PlayerPrefs.SetString("startTime", startTime.ToString());
        PlayerPrefs.SetString("elapsedTime", elapsedTime.ToString());
        PlayerPrefs.SetInt("isTimerRunning", isTimerRunning ? 1 : 0);
    }

    private void OnApplicationQuit()
    {
        SaveTimerState();
    }

    private void UpdateTimerText()
    {
        int minutes = (int)elapsedTime.TotalMinutes;
        int seconds = elapsedTime.Seconds;
        timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void InitializeTime()
    {
        if (isTimerRunning)
        {
            TimeSpan timePassed = DateTime.Now - startTime;
            elapsedTime -= timePassed;
        }
        else
        {
            elapsedTime = TimeSpan.FromMinutes(5);
        }

        startTime = DateTime.Now;
        isTimerRunning = true;
    }


}
