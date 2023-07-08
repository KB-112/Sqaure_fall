using GoogleMobileAds.Sample;
using UnityEngine;
using UnityEngine.UI;

public class LoadRewardedAds : MonoBehaviour
{

    public Button RewardeAds;

    public void Start()
    {
        RewardeAds.onClick.AddListener(Loadads);
    }
    public void Loadads()
    {
        RewardedAds.instance.ShowAd();
        Debug.Assert(RewardeAds.onClick != null);
        
    }

   

}
