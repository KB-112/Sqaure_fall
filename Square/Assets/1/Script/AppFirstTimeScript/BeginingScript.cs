using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BeginingScript : MonoBehaviour
{
    public GameObject[] obj;
    int pressfirsttime;
    public Button pressbtn;
    public CurrencyManager Cm;

    public void Start()
    {

        PlayerPrefs.GetInt("FirstTime");


        if (PlayerPrefs.HasKey("FirstTime") )
        { 
            for (int i = 0; i < obj.Length; i++)
            {
                obj[i].SetActive(false);
            }
            // Add the logic for initializing the game here.
            Cm.totalContractorScore = 50;

           

            
        }

       
        pressbtn.onClick.AddListener(IntialStage);
    }

    void IntialStage()
    {
    
        
        

        if (pressfirsttime ==0)
        {
            Cm.totalContractorScore = 50;



            for (int i = 0; i <obj.Length; i ++ )
            {
                obj[i].SetActive(false);
            }

            pressfirsttime++;
            Debug.Log("pressfirsttime on IntialStage: " + pressfirsttime);

            PlayerPrefs.SetInt("FirstTime", pressfirsttime);
            PlayerPrefs.Save();
        }

    }
}
