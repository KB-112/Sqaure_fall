using GoogleMobileAds.Api;
using GoogleMobileAds.Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBannerAdsForMainGameplay : MonoBehaviour
{

    public Button TapToShoot;

   
    private void Start()
    {
    
        TapToShoot.onClick.AddListener(OnButtonClick);
        StartCoroutine(A());
    }
    IEnumerator A()
    {
        yield return new WaitForSeconds(5f);
        BannerAds.Instance.LoadAd();
        Debug.Log("Banner Ads Position change");
    }


   
    public void OnButtonClick()
    {
       


    }


}
