using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds;
using GoogleMobileAds.Sample;

public class MultipleAds : MonoBehaviour
{
    public Button MixAdsBtn;

    public void OnButtonClick()
    {
        StartCoroutine(ShowAds());
    }

    public void Start()
    {
        MixAdsBtn.onClick.AddListener(OnButtonClick);
    }

    IEnumerator ShowAds()
    {
        if (RewardedAds.instance._rewardedAd != null && RewardedAds.instance._rewardedAd.CanShowAd())
        {
            RewardedAds.instance.ShowAd();
        }
        else
        {
            InterAds.instance.ShowAd();
            while (InterAds.instance._interstitialAd != null) 
            {
                yield return null;
            }
            if (RewardedAds.instance._rewardedAd != null && RewardedAds.instance._rewardedAd.CanShowAd())
            {
                RewardedAds.instance.ShowAd();
            }
        }
    }


}
