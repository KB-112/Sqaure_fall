using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleSystem : MonoBehaviour
{
    public ParticleSystem destroyParticlesystem;
    

    void Start()
    {
        destroyParticlesystem = GetComponent<ParticleSystem>();
        destroyParticlesystem.Stop();

       
        
        
    }

  public  void UnpauseParticleSystem()
    {
        destroyParticlesystem.Play();
     //   var main = destroyParticlesystem.main;
     //   main.useUnscaledTime = true;

    }
}
