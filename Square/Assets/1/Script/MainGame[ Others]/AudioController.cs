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

        // load the state of the sound button on scene reload
        if (PlayerPrefs.HasKey("SoundOn"))
        {
            isActivated1 = PlayerPrefs.GetInt("SoundOn") == 1;
        }
        else
        {
            isActivated1 = true;
        }

        if (isActivated1)
        {
            audioMixer.SetFloat("Vol", 0f);
            spriteRenderer.sprite = soundOn;
        }
        else
        {
            audioMixer.SetFloat("Vol", -80f);
            spriteRenderer.sprite = soundOff;
        }
    }

    public void SoundPanelButton()
    {
        isActivated1 = !isActivated1;
        if (isActivated1)
        {
            audioMixer.SetFloat("Vol", 0f);
            spriteRenderer.sprite = soundOn;
        }
        else
        {
            audioMixer.SetFloat("Vol", -80f);
            spriteRenderer.sprite = soundOff;
        }

        // save the state of the sound button
        PlayerPrefs.SetInt("SoundOn", isActivated1 ? 1 : 0);
        PlayerPrefs.Save();
    }




}
