using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadRewardedAds : MonoBehaviour
{


    public void Loadads()
    {
        Debug.Log("rewards btn");
        StartCoroutine(ShowRewardedAdCoroutine());
    }

    IEnumerator ShowRewardedAdCoroutine()
    {
        yield return null;


        RewardedAds.instances.ShowRewardedAd();
        
    }

}
