using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btnstate : MonoBehaviour
{
    public Button ntn;
    string btn = "key";
    bool buttonState = false; // Initialize buttonState as false

    public void BtnPress()
    {
        buttonState = true; // Set buttonState to true after button press
        PlayerPrefs.SetInt(btn, 1);
        PlayerPrefs.Save();
        ntn.interactable = false;
        StartCoroutine(A());
    }

    public void Start()
    {
        if (PlayerPrefs.HasKey(btn) || !ntn.interactable)
        {
            buttonState = true; // Set buttonState to true on application start if conditions met
            ntn.interactable = false;
            StartCoroutine(A());
        }
    }

    IEnumerator A()
    {
        yield return new WaitForSeconds(0);
        ntn.interactable = true;
        Debug.Log("Task complete");
    }

    public void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            Debug.Log("Application resumed");
        }
        else
        {
            Debug.Log(" : ) Saving TIME");
        }
    }
    
}