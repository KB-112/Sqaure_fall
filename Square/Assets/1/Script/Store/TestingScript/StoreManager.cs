using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager 
{
    //ButtonManager DataType ---------------
    public  int newButtonIndex;
    public  int buttonIndex;
    public Button[] contractorDoublerbtn;
    public bool checkButtonClicked;
    public bool timerend;
    //TimerManager DataTypes ----------------
    public DateTime startTime;
    public DateTime endTime;
    public TimeSpan elapsedTime;
    public TimeSpan remainingTime;
    public TextMeshProUGUI[] TimeText;
    public TimeSpan[] OneDayCards = new TimeSpan[5];
    //PlayerPrefs ----------------
    public const string key1 = "BtnPressedContractDoubler";
    public const string key2 = "StartTime";
    //Instances -----------------
    public static StoreManager instance;
    //Test
    public  int test = 7;
    private StoreManager()
    {
        // Private constructor to prevent instantiation
    }

  
    static StoreManager()
    {
        instance = new StoreManager();
    }

    public static StoreManager GetInstance()
    {
        return instance;
    }
    
        public int IndexOfButton(int savingBtnIndex)
        { newButtonIndex = savingBtnIndex;
            return -1;
        }
    
}



