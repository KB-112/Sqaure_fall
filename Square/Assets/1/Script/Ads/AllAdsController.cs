using GoogleMobileAds.Api;
using GoogleMobileAds.Sample;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllAdsController : MonoBehaviour
{
    public Button MixAdsBtn;
    

    public void Awake()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {


            Debug.Assert(initStatus != null);

        });
        DontDestroyOnLoad(gameObject);    
    }
    private void Start()
    {
        StartCoroutine(A());
        MixAdsBtn.onClick.AddListener(OnButtonClick);
       
    }
    IEnumerator A()
    {
        yield return null;
        BannerAds.instance.LoadAd();
      
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
