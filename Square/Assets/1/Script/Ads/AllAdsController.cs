using GoogleMobileAds.Api;
using GoogleMobileAds.Sample;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AllAdsController : MonoBehaviour
{
    public Button MixAdsBtn;


    

    public void Awake()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {


            Debug.Assert(initStatus != null);

        });
        
    }
    private void Start()
    {
        if(SceneManager.GetActiveScene().name =="StartScene")
        {
            StartCoroutine(A());
        }
       




        MixAdsBtn.onClick.AddListener(OnButtonClick);
       
    }
    IEnumerator A()
    {
        yield return null;
        BannerAds.Instance.LoadAd();
      
    }


    IEnumerator B()
    {
        yield return null;
        RewardedInterstitialAdController.instance.ShowAd();
    }
    public void OnButtonClick()
    {
        StartCoroutine(B());
     
      
    }

  
}
