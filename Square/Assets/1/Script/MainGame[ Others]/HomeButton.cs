using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HomeButton : MonoBehaviour
{
    public void HomeBtn()
    {
       
        SceneManager.LoadSceneAsync("StartScene");

        Debug.Log("Home scene Loaded");
    }

}
