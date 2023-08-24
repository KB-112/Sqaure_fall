using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class playerrevival : MonoBehaviour
{
    public int finalQuantavalue;
    public int coisUsed = 5;

    public TextMeshProUGUI finalQuantavaluetxt;
    public TextMeshProUGUI revivalquantacoins;

    public Button revivalbtn;

    public enum maxquantacoinspent
    {
        firsttime = 0,
        secondtime = 1,
        thirdTime = 2,
        fourthtime
    }

    [SerializeField]
    private maxquantacoinspent currentCase;

    public int revivalcount;

    public void Start()
    {
        // Reset all PlayerPrefs data on scene reload
        PlayerPrefs.DeleteAll();

        finalQuantavalue = PlayerPrefs.GetInt("sharescore");
        finalQuantavaluetxt.text = finalQuantavalue.ToString();
        revivalbtn.onClick.AddListener(Revive); // Listen to the revival button click
        currentCase = maxquantacoinspent.firsttime; // Set the initial case
        UpdateCoinsUsedText(); // Display coins used initially
    }

    public void UpdateCoinsUsedText()
    {
        switch (currentCase)
        {
            case maxquantacoinspent.firsttime:
                coisUsed = 5;
                break;
            case maxquantacoinspent.secondtime:
                coisUsed = 25;
                break;
            case maxquantacoinspent.thirdTime:
                coisUsed = 30;
                break;
            case maxquantacoinspent.fourthtime:
                // End of cases, do not update coisUsed
                return;
        }

        revivalquantacoins.text = coisUsed.ToString(); // Display coins used
    }

    public void Revive()
    {
        // Handle the revival process here
        // For example, deduct coins based on the current case (coisUsed)
        // and perform the revive operation.

        // Move to the next case
        MoveToNextCase();

        // Update the coins used text
        UpdateCoinsUsedText();
    }

    private void MoveToNextCase()
    {
        int nextCaseValue = PlayerPrefs.GetInt("DeathCount");

        switch (nextCaseValue)
        {
            case 0:
                currentCase = maxquantacoinspent.secondtime; // Move to the second case
                break;
            case 1:
                currentCase = maxquantacoinspent.thirdTime; // Move to the third case
                break;
            case 2:
                currentCase = maxquantacoinspent.fourthtime; // Move to the fourth case
                break;
            default:
                currentCase = maxquantacoinspent.fourthtime;
                break;
        }

        Debug.Log("nextCaseValue-->" + nextCaseValue);
    }
}
