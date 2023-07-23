using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    StoreManager Smi = StoreManager.GetInstance();
    public TextMeshProUGUI[] NewtimeText;

    private void Start()
    {


        Smi.OneDayCards[0] = TimeSpan.FromSeconds(1);
        Smi.OneDayCards[1] = TimeSpan.FromSeconds(2);
        Smi.OneDayCards[2] = TimeSpan.FromSeconds(7);
        Smi.OneDayCards[3] = TimeSpan.FromSeconds(14);
        Smi.OneDayCards[4] = TimeSpan.FromSeconds(30);

    }

    public void Update()
    {
        if (!Smi.checkButtonClicked)
        {
            return;
        }
        else
        {
            Smi.endTime = DateTime.Now;
            Smi.elapsedTime = Smi.endTime - Smi.startTime;

            // Smi.IndexOfButton(Smi.newButtonIndex);

            int indexingoftimer = Smi.newButtonIndex;
            Debug.Log(indexingoftimer);
            if (Smi.elapsedTime >= Smi.OneDayCards[indexingoftimer])
            {
                for (int i = 0; i < Smi.contractorDoublerbtn.Length; i++)
                {
                    Smi.contractorDoublerbtn[i].interactable = true;

                }

                return;
            }

            // Calculate remaining time
            Smi.remainingTime = Smi.OneDayCards[indexingoftimer] - Smi.elapsedTime;
            Smi.TimeText[indexingoftimer].text = Smi.remainingTime.ToString(@"hh\:mm\:ss");
        }

    }

}
