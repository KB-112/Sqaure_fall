using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{   
    public GameObject togglebtn;
    public Button Storebtn;
    private void Start()
    {
        Storebtn.onClick.AddListener(ToggleImageActivation);
    }
    private void ToggleImageActivation()
    {
        if(!togglebtn.activeSelf)
        {
           
           togglebtn.SetActive(true);
        }
        else
        {
            togglebtn.SetActive(false);
        }
        
        
    }
}


