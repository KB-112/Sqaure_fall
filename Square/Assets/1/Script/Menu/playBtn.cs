using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


using UnityEngine.SceneManagement;
public class playBtn : MonoBehaviour
{
  
   private Button button;


    private Vector2 originalScale;

    private float decreaseFactor = 0.8f;
    private float returnTime = 0.2f;

    public MenuCanvasObj menuCanvas;

  public bool isPlaying = false;

 

    public void Start()
    {

    
        button = GetComponent<Button>();
        originalScale = button.transform.localScale;
    }
    public void OnClick()
    { 
        Vector2 newScale = originalScale * decreaseFactor;
        button.transform.localScale = newScale;
        
        StartCoroutine(ReturnButtonToOriginalScale());
        isPlaying = true;
        SceneManager.LoadSceneAsync("Scene",LoadSceneMode.Additive);
        StartCoroutine(SceneUnload());
    }

   
       
    IEnumerator ReturnButtonToOriginalScale()
    {   
        yield return new WaitForSeconds(returnTime);
        button.transform.localScale = originalScale;
    }

    private void Update()
    {if (isPlaying)
        {
            menuCanvas.MainGameCall();
        }
        else
        {
            return;
        }
       
    }

    IEnumerator SceneUnload()
    {
        yield return new WaitForSeconds (2f);
        SceneManager.UnloadSceneAsync("StartScene");
    }
}
