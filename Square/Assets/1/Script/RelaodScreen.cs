using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RelaodScreen : MonoBehaviour
{
    private SceneManager scene;
    public SoundSystem soundSystem;

  

    public GameObject Menu;
    public void Start()
    {
       // scene = GetComponent<SceneManager>();

    }

    public void O()
    {
        soundSystem.button();
        SceneManager.LoadSceneAsync("Scene");
        
        Debug.Log("scene Loaded");
    }

   
   
}

