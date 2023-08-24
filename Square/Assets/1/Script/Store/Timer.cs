using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
   DateTime startTime;
     DateTime currentTime;
    TimeSpan elapsedTime;
     TimeSpan remainingTime;

    public TextMeshProUGUI[] TimeText;
    public Button[] ContractorDoublerbtn;
    bool checkButtonClicked;

    TimeSpan[] OneDayCards = new TimeSpan[5];
    
    int buttonIndex;

    private void Start()
    {
        
        checkButtonClicked = false;
        

        // Add button click listeners with lambda expressions
        for (int i = 0; i < ContractorDoublerbtn.Length; i++)
        {
            int index = i;
            ContractorDoublerbtn[i].onClick.AddListener(() =>
            {
                newbtn(index);
            });
        }

        // Assign predefined time intervals
        OneDayCards[0] = TimeSpan.FromSeconds(1);
        OneDayCards[1] = TimeSpan.FromSeconds(2);
        OneDayCards[2] = TimeSpan.FromSeconds(7);
        OneDayCards[3] = TimeSpan.FromSeconds(14);
        OneDayCards[4] = TimeSpan.FromSeconds(30);


    }

    private void Update()
    {
        if (!checkButtonClicked)
        {
            return;
        }
        else
        {
            // Calculate elapsed time
            currentTime = DateTime.Now;
            elapsedTime = currentTime - startTime;

            newbtn(buttonIndex);
        }
    }

    public void newbtn(int c)
    {
        buttonIndex = c;
        if (elapsedTime >= OneDayCards[buttonIndex])
        {
            // Card is interactable
            for (int i = 0; i < ContractorDoublerbtn.Length; i++)
            {
                ContractorDoublerbtn[i].interactable = true;
            }
            return;
        }

        // Calculate remaining time
        remainingTime = OneDayCards[buttonIndex] - elapsedTime;
        TimeText[buttonIndex].text = remainingTime.ToString(@"hh\:mm\:ss");
    }

    
    public void TimerintialStage()
    {
        // Initialize timer
        startTime = DateTime.Now;

        // Disable all buttons
        for (int i = 0; i < ContractorDoublerbtn.Length; i++)
        {
            ContractorDoublerbtn[i].interactable = false;
        }

        checkButtonClicked = true;
    }
}
