using GoogleMobileAds.Sample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickInterstetialads : MonoBehaviour
{
    public Button InterstitalButton;


    private void Start()
    {
        InterstitalButton.onClick.AddListener(LoadlAds);
    }

    public void LoadlAds()
    {
        InterAds.instance.ShowAd();
        Debug.Log("Interstial ads Clicked ");
      

    }

   

}
