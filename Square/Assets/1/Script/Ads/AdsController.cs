using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsController : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(A());
    }

    IEnumerator A()
    {
        yield return null;
      BannerAds.instance.LoadAd();
    }

}
