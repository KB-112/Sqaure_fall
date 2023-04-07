using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleSystem : MonoBehaviour
{
    public ParticleSystem destroyParticlesystem;
    

    void Start()
    {
        destroyParticlesystem = GetComponent<ParticleSystem>();
       
        
    }

  public  void UnpauseParticleSystem()
    {
        destroyParticlesystem.Play();
        

    }

    public void NonActive()
    {
        this.gameObject.SetActive(false);


    }

}
