﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectControl : MonoBehaviour {
    public static SoundEffectControl Instance;
    public AudioClip[] SoundEffect;
    [Range(0, 100)] [SerializeField]private float VolSoundEffect;
   
    // Use this for initialization
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are multiple instances of the SoundEffectController script.");
        }

        Instance = this;
        
    }
    
    public void MakeExplosionSound()
    {
        MakeSound(SoundEffect[0]);
    }

    public void MakePlayerShotSound()
    {
        MakeSound(SoundEffect[1]);
    }

    
    public void MakeColetableSound()
    {
        MakeSound(SoundEffect[2]);
        
    }
    
    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position, VolSoundEffect);
        
    }
}