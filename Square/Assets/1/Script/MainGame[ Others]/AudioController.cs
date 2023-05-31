using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class AudioController : MonoBehaviour
{

   
    private bool isActivated1 = false;
    public GameObject audios;
    public Sprite soundOn;
    public Sprite soundOff;
    private Image spriteRenderer;

    public AudioMixer audioMixer;
    float valuecheck;
    private void Start()
    {
        spriteRenderer = audios.GetComponent<Image>();


        if (PlayerPrefs.HasKey("AudioState"))
        {
            float savedValue = PlayerPrefs.GetFloat("AudioState");

            if (savedValue == -80f)
            {
                audioMixer.SetFloat("Vol", -80f);
                spriteRenderer.sprite = soundOff;
            }
            else
            {
                audioMixer.SetFloat("Vol", 0f);
                spriteRenderer.sprite = soundOn;
            }
        }
        else
        {
            audioMixer.SetFloat("Vol", 0f);
            spriteRenderer.sprite = soundOn;
        }


    }
    

    public void SoundPanelButton()
    {           
        isActivated1 = !isActivated1;
        if (isActivated1 )
        {
            audioMixer.SetFloat("Vol", 0f);
            spriteRenderer.sprite = soundOn;
            PlayerPrefs.SetFloat("AudioState", 0);
        }
        if (!isActivated1 )
        {
            
            audioMixer.SetFloat("Vol", -80f);
            spriteRenderer.sprite =soundOff;
            PlayerPrefs.SetFloat("AudioState",-80);



        }

        PlayerPrefs.Save();
    }
}
