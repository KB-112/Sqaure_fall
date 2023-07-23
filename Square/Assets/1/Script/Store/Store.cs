using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public GameObject[] togglebtn;
    public Button Storebtn;
    public Button spinWheeler;

    private void Start()
    {
        Storebtn.onClick.AddListener(ToggleImageActivation);
        spinWheeler.onClick.AddListener(SpinWheeler);
    }

    private void ToggleImageActivation()
    {
        if (!togglebtn[0].activeSelf)
        {
            togglebtn[0].SetActive(true);
        }
        else
        {
            togglebtn[0].SetActive(false);
        }
    }

    public void SpinWheeler()
    {
        togglebtn[1].SetActive(true);
        StartCoroutine(ExitWheeler());
    }

    IEnumerator ExitWheeler()
    {
        yield return new WaitForSeconds(5f);
        togglebtn[1].SetActive(false);
    }
}
