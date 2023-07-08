using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.ComponentModel;

public class Contractor : MonoBehaviour
{
    // Public variables
    [HideInInspector] public int Totalcontractor;
    public int Newcontractorvalue;
    public int contractorReductionPerplay;
    [SerializeField][ReadOnlyInspector] public int playButtonPressCount = 1;
    public TextMeshProUGUI scoreText;

    // PlayerPrefs keys
    private const string PressedPlayButtonKey = "PressedPlayButton";
    private const string TotalContractorKey = "TotalContractor";
    public Button PlayButton;
    [SerializeField] public int adcoin;
    public Button WatchAdsButton;
    private const string adcoinKey = "adCoin";
   

    int storecoins;
    bool adsbtn = false;


    public int Quantacoins;
    public TextMeshProUGUI QuantaText; 





    private void Start()
    {
        // Check if PlayerPrefs has the key for play button press count
        if (!PlayerPrefs.HasKey(PressedPlayButtonKey))
        {
            // Set the initial value for Totalcontractor if the key is not found
            Totalcontractor = Newcontractorvalue;
        }
        else
        {
            // Load the saved values from PlayerPrefs
            playButtonPressCount = PlayerPrefs.GetInt(PressedPlayButtonKey, playButtonPressCount);
            Totalcontractor = PlayerPrefs.GetInt(TotalContractorKey, Totalcontractor);
            adcoin = PlayerPrefs.GetInt(adcoinKey, adcoin);
           

            WatchAdsButton.onClick.AddListener(watchads);
            if (adsbtn)
            {
                Debug.Log("Ads button Pressed");
                storecoins = adcoin;
                Totalcontractor = Newcontractorvalue + storecoins;
               
            }

            // Reduce Totalcontractor based on contractorReductionPerplay
            Totalcontractor -= contractorReductionPerplay;

            // Check if Totalcontractor is zero or negative
            if (Totalcontractor >= 0)
            {
                PlayButton.enabled = true;
                
            }
            else
            {
                PlayButton.enabled = false;

            }
        }

        // Update the score text
        scoreText.text = Totalcontractor.ToString();

        Quantacoins = adcoin * 5;
        QuantaText.text = Quantacoins.ToString();
    }

    public void PlayBtnCounter()
    {
        // Increment the play button press count
        playButtonPressCount++;

        // Save the play button press count and Totalcontractor to PlayerPrefs
        PlayerPrefs.SetInt(PressedPlayButtonKey, playButtonPressCount);
        PlayerPrefs.SetInt(TotalContractorKey, Totalcontractor);
        PlayerPrefs.SetInt(adcoinKey, adcoin);
     

        
       

        // Save the changes to PlayerPrefs
        PlayerPrefs.Save();
    }

    public void watchads()
    {
        adsbtn = true;
        Totalcontractor += adcoin; // Increase Totalcontractor by the value of adcoin
        scoreText.text = Totalcontractor.ToString(); // Update the score text

        Quantacoins = adcoin * 5; // Calculate the new value for QuantaCoins
        QuantaText.text = Quantacoins.ToString(); // Update the QuantaText
    }

}
