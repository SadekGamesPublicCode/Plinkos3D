using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettingSC : Singleton<PlayerSettingSC>
{
    [SerializeField] AudioClip maintheme;
    [SerializeField] AudioClip dropEffectSound;
    [SerializeField] AudioSource mainsound;
    [SerializeField] AudioSource dropSound;

    [HideInInspector]
    private bool isPlaySound; //Update this later

    private void Start()
    {
        DecidePlaySound();
    }
    void DecidePlaySound()
    { 
        //Custome this depend on option panel choices on BMG on/off
        mainsound.Play();
    }
    public void PlayDropSound()
    {
        //Custome this depend on option panel choices on sound effect on/off
        
    }
}
