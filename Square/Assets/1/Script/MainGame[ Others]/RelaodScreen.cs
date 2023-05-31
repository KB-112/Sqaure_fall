using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RelaodScreen : MonoBehaviour
{
   
    public SoundSystem soundSystem;

  

   
    public void O()
    {
        soundSystem.button();
        SceneManager.LoadSceneAsync("Scene");
        
        Debug.Log("scene Loaded");
    }
   


}

