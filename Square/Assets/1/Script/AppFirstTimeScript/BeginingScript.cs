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
        pressfirsttime = PlayerPrefs.GetInt("FirstTime", pressfirsttime);
        if (PlayerPrefs.HasKey("FirstTime") && pressfirsttime == 1)
        {
            for (int i = 0; i < obj.Length; i++)
            {
                obj[i].SetActive(false);
            }
        }
        pressbtn.onClick.AddListener(IntialStage);

    }
    void IntialStage()
    {
        pressfirsttime++;
        
        PlayerPrefs.SetInt("FirstTime", pressfirsttime);
        PlayerPrefs.Save();

        if (pressfirsttime ==1)
        {
            Cm.totalContractorScore = 50;



            for (int i = 0; i <obj.Length; i ++ )
            {
                obj[i].SetActive(false);
            }



        }

    }
}
