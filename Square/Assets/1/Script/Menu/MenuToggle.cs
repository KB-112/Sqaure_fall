using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuToggle : MonoBehaviour
{
    [SerializeField] private GameObject WatchedAds;
    [SerializeField] private GameObject TimeskipAds;
    [SerializeField] private GameObject WatchAdsBg;


    [SerializeField] private GameObject WheelSpinnerBg;
    [SerializeField] private GameObject TapToskip;


    // Cache the button references
    [SerializeField] private Button WatchAdsBtn;
    [SerializeField] private Button CloseAdsBtn;
    [SerializeField] private Button TimeSkipAdsBtn;
    [SerializeField] private Button OkayBtn;

    [SerializeField] private Button SpinWheelerBtn;
    [SerializeField] private Button CloseWheelerBtn;
    [SerializeField] private Button SpinNowBtn;



    [SerializeField] public float wheelerTImeClosed;

    bool startWheelerTimer;


    private void Awake()
    {
       TapToskip.SetActive(false);
    }
    private void Start()
    {
        // Add listeners to buttons
        WatchAdsBtn.onClick.AddListener(ShowWatchAdsWindow);
        TimeSkipAdsBtn.onClick.AddListener(ShowTimeSkipWindow);
        CloseAdsBtn.onClick.AddListener(CloseWatchAdsWindow);
        OkayBtn.onClick.AddListener(CloseTimeSkipWindow);
        SpinWheelerBtn.onClick.AddListener(SpinWheelerActivation);
        CloseWheelerBtn.onClick.AddListener(CloseWheeler);
        SpinNowBtn.onClick.AddListener(SpinHere);

    }

    public void ShowWatchAdsWindow()
    {
        WatchedAds.SetActive(true);
        WatchAdsBg.SetActive(true);
    }

    public void ShowTimeSkipWindow()
    {
        WatchedAds.SetActive(false);
        TimeskipAds.SetActive(true);
    }

    public void CloseWatchAdsWindow()
    {
        WatchedAds.SetActive(false);
        WatchAdsBg.SetActive(false);
    }

    public void CloseTimeSkipWindow()
    {
        TimeskipAds.SetActive(false);
        WatchAdsBg.SetActive(false);
    }

    public void SpinWheelerActivation()
    {

        WheelSpinnerBg.SetActive(true);
        startWheelerTimer = false;
    }

    public void CloseWheeler()
    {
       WheelSpinnerBg.SetActive(false);
        TapToskip.SetActive(false);
    }
    IEnumerator ExitWheeler()
    {
        yield return new WaitForSeconds(wheelerTImeClosed);
        TapToskip.SetActive(true);
    }

    public void SpinHere()
    {
        startWheelerTimer = true;
        if (startWheelerTimer)
        {
            StartCoroutine(ExitWheeler());
           
        }
    }
}
