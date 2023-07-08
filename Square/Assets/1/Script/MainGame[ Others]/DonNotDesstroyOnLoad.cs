using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DonNotDesstroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] LoadedObj;

    void Awake()
    {
        for(int i = 0; i < LoadedObj.Length; i++)
        {
            DontDestroyOnLoad(LoadedObj[i]);
        }
        
    }

   
}
