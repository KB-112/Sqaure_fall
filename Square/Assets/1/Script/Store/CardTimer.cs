using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
public class CardTimer : MonoBehaviour
{
    public TextMeshProUGUI timertext;

    private DateTime startTime;
    private TimeSpan elapsedTime;
    private bool isTimerRunning;

    public bool btnressed = false;

    public void Start()
    {
        btnressed = false;
    }
    public void BtnTester()
    {
        btnressed = true;
        LoadTimerState();

        if (isTimerRunning)
        {
            TimeSpan timePassed = DateTime.Now - startTime;
            elapsedTime -= timePassed;
        }
        else
        {
            elapsedTime = TimeSpan.FromSeconds(20);
        }

        startTime = DateTime.Now;
        isTimerRunning = true;

        StartCoroutine(UpdateTimerCoroutine());


    }

    private IEnumerator UpdateTimerCoroutine()
    {
        while (elapsedTime.TotalSeconds > 0)
        {
            elapsedTime -= TimeSpan.FromSeconds(1);
            UpdateTimerText();
            yield return new WaitForSecondsRealtime(1f);
        }

        StopTimer();
    }

    private void StopTimer()
    {
        isTimerRunning = false;
    }

    private void LoadTimerState()
    {
        string startTimeString = PlayerPrefs.GetString("startTime", "");
        startTime = !string.IsNullOrEmpty(startTimeString) ? DateTime.Parse(startTimeString) : DateTime.Now;

        string elapsedTimeString = PlayerPrefs.GetString("elapsedTime", "");
        elapsedTime = !string.IsNullOrEmpty(elapsedTimeString) ? TimeSpan.Parse(elapsedTimeString) : TimeSpan.FromSeconds(20);

        isTimerRunning = PlayerPrefs.GetInt("isTimerRunning", 0) == 1;
    }

    private void SaveTimerState()
    {
        PlayerPrefs.SetString("startTime", startTime.ToString());
        PlayerPrefs.SetString("elapsedTime", elapsedTime.ToString());
        PlayerPrefs.SetInt("isTimerRunning", isTimerRunning ? 1 : 0);
    }

    private void OnApplicationPause(bool pauseStatus)
    {


        if (pauseStatus)
        {
            SaveTimerState();
        }
        else
        {
            LoadTimerState();
            StartCoroutine(UpdateTimerCoroutine());
        }

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
}
