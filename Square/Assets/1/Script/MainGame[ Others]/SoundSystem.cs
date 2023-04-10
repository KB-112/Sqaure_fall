using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    [Header("SOUND SYSTEM")]
    AudioSource sound;
    public AudioClip[] impact;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    public void rebound()
    {
        sound.PlayOneShot(impact[0]);
    }
    public void move()
    {
        sound.PlayOneShot(impact[1]);
    }
   
    public void explode()
    {
        sound.PlayOneShot(impact[2]);
    }
   
    public void point()
    {
        sound.PlayOneShot(impact[3]);
    }
 
    public void button()
    {
        sound.PlayOneShot(impact[4]);
    }
}
