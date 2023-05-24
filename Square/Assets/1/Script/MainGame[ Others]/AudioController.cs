using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioController : MonoBehaviour
{

   
    private bool isActivated1 = false;

    public GameObject audios;
    public Sprite soundOn;
    public Sprite soundOff;
    private Image spriteRenderer;

    private void Start()
    {
        spriteRenderer = audios.GetComponent<Image>();
    }

 
    public void SoundPanelButton()
    {



        isActivated1 = !isActivated1;
        if (isActivated1 )
        {
            spriteRenderer.sprite = soundOn;
        }
        if (!isActivated1 )
        {
            spriteRenderer.sprite =soundOff;
        }

    }
}
