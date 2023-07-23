using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreButtonManager : MonoBehaviour
{
    private const bool F = false;
    private const bool T = true;
    public Button[] contractorNewbtn;

    private bool codeExecuted = false;
    StoreManager Smi = StoreManager.GetInstance();


   
    private void Start()
    { 
    Smi.contractorDoublerbtn = contractorNewbtn ;
        
        for (int i = 0; i < contractorNewbtn.Length; i++)
        {
            int cd = i;
            contractorNewbtn[i].onClick.AddListener(() => Smi.IndexOfButton(cd));
            Debug.Log(Smi.buttonIndex);
        }

        
    }
  //Index Testing ---------------------------
  /*  public void A(int c )
    {
        Smi.buttonIndex = c;
        Debug.Log("--->>"+Smi.buttonIndex);
    }*/

    public void OnButtonCLick()
    {
        Smi.startTime = DateTime.Now;
        Smi.checkButtonClicked = true;

        for (int i = 0; i < Smi.contractorDoublerbtn.Length; i++)
        {
          contractorNewbtn[i].interactable = F;
        }
        Debug.Log("Button F Execution Sucess");
       
    }

   


}
