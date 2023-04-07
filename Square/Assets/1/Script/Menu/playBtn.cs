using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


using UnityEngine.SceneManagement;
public class playBtn : MonoBehaviour
{
    public AudioClip clip;
     AudioSource source;
   private Button button;


    private Vector2 originalScale;

    private float decreaseFactor = 0.8f;
    private float returnTime = 0.2f;

    public MenuCanvasObj menuCanvas;

  public bool isPlaying = false;

 

    public void Start()
    {

    
        source = GetComponent<AudioSource>();
        button = GetComponent<Button>();
        originalScale = button.transform.localScale;
    }
    public void OnClick()
    { 
        Vector2 newScale = originalScale * decreaseFactor;
        button.transform.localScale = newScale;
        source.PlayOneShot(clip);
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
