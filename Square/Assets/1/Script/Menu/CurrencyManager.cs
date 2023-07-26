using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using GoogleMobileAds.Sample;

public class CurrencyManager : MonoBehaviour
{
    
    public int totalContractorScore;
    public int appIntitalStage;

    public TextMeshProUGUI TotalContractorvalue;


    //--------Subtraction
    public Button PlayBtn;
    private int playerScore;
    private int playbtncount;

    //-------------QuantaCoins

    public int Quantacoins ;
    public TextMeshProUGUI TotalQuantavalue;
    public int QuantRewardValue ;

    public Button okbtn;
    public Button SpentQuantaCoin;
    public int coin;

    public void Start()
    {
        if (!PlayerPrefs.HasKey("TotalScore"))
        {
            playerScore = 0;
            PlayerPrefs.SetInt("TotalScore", playerScore);
            PlayerPrefs.Save();
        }
        else
        {
            playerScore = PlayerPrefs.GetInt("TotalScore");
        }
        playbtncount = PlayerPrefs.GetInt("PlayBtnCount");
        UpdateTotalContractorScore();

        TotalContractorvalue.text = totalContractorScore.ToString();

        PlayBtn.onClick.AddListener(clickplayBtn);

        //-----------------Quantacoins
        Quantacoins = PlayerPrefs.GetInt("SpentQuantCoin");
        Quantacoins = PlayerPrefs.GetInt("QuantCoin");
       
        TotalQuantavalue.text = Quantacoins.ToString();



        okbtn.onClick.AddListener(clickOkbtn);
        SpentQuantaCoin.onClick.AddListener(SpentQuantaCoinBtn);
        if(totalContractorScore ==0)
        {
            PlayBtn.enabled = false;
        }
        else
        {
            PlayBtn.enabled = true;
        }

    }

    public void  SpentQuantcoin()
    {
        coin = 50;
        Quantacoins -= coin;

    }
    public void SpentQuantaCoinBtn()
    {
        SpentQuantcoin();
        TotalQuantavalue.text = Quantacoins.ToString();
        PlayerPrefs.SetInt("SpentQuantCoin", Quantacoins);
        PlayerPrefs.Save();
    }

    private void UpdateTotalContractorScore()
    {
        totalContractorScore = playerScore - playbtncount;
    }

    public void AddingQuantaCoins()
    {
        QuantRewardValue = 50;
        Quantacoins += QuantRewardValue;
    }
    public void clickOkbtn()
    {

        if (RewardedInterstitialAdController.Quantacoinsreward)
        {
            AddingQuantaCoins();
           
        }
        TotalQuantavalue.text = Quantacoins.ToString();
        PlayerPrefs.SetInt("QuantCoin", Quantacoins);
        PlayerPrefs.Save();

    }


    public void clickplayBtn()
    {
        playbtncount++;
        UpdateTotalContractorScore();
        TotalContractorvalue.text = totalContractorScore.ToString();

        // Save the updated playbtncount and totalContractorScore in PlayerPrefs
        PlayerPrefs.SetInt("PlayBtnCount", playbtncount);
        PlayerPrefs.SetInt("FinalScore", totalContractorScore);
        PlayerPrefs.Save();
    }



   
}
