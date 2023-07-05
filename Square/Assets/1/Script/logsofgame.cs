using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class logsofgame : MonoBehaviour
{
    public Toggle toggle;
    public GameObject obj1;
    public TMP_Text debugText;
    private string consoleLog = "";
    private int currentLogIndex = 0;  // Current log index for scrolling

    void Start()
    {
        Application.logMessageReceived += HandleLogMessage;
        UpdateTextMeshPro();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    void HandleLogMessage(string logMessage, string stackTrace, LogType logType)
    {
        int lineNumber = consoleLog.Split('\n').Length;
        consoleLog += lineNumber.ToString() + ": " + logMessage + "\n";
        UpdateTextMeshPro();
    }

    void UpdateTextMeshPro()
    {
        debugText.text = consoleLog;
    }

    public void ScrollLogUp()
    {
        currentLogIndex--;
        if (currentLogIndex < 0)
            currentLogIndex = 0;
        UpdateTextMeshPro();
    }

    public void ScrollLogDown()
    {
        int numLines = consoleLog.Split('\n').Length;
        currentLogIndex++;
        if (currentLogIndex >= numLines)
            currentLogIndex = numLines - 1;
        UpdateTextMeshPro();
    }
    private void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {obj1.SetActive(true);
           

        }
        else
        {
            obj1.SetActive(false);
           
        }
    }
}
