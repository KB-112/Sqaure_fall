using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuToggle : MonoBehaviour
{
    public GameObject WatchedAds;
    public GameObject TimeskipAds;
    public GameObject WatchAdsBg;


    public Button WatchAdsBtn;
    public Button CloseAdsBtn;
    public Button TimeSkipAdsBtn;
    public Button OkayBtn; 
    private void Start()
    {
       

        WatchAdsBtn.onClick.AddListener(WantToSeeAdsWindow);
       TimeSkipAdsBtn.onClick.AddListener(TimeSkipWindow);
        CloseAdsBtn.onClick.AddListener(QuitWatchAdsWindow);
        OkayBtn.onClick.AddListener(QuitTimeskipWindow);


    }
    public void WantToSeeAdsWindow()
    {
        WatchedAds.SetActive(true);
        WatchAdsBg.SetActive(true);
    }
    public void TimeSkipWindow()
    {
        WatchedAds.SetActive(false);
        TimeskipAds.SetActive(true);
    }
     

    public void QuitWatchAdsWindow()
    {
        WatchedAds.SetActive(false);
        WatchAdsBg.SetActive(false);
    }

    public void QuitTimeskipWindow()
    {
        TimeskipAds.SetActive(false);
        WatchAdsBg.SetActive(false);
    }

}
