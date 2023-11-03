using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettingSC : Singleton<PlayerSettingSC>
{
    [SerializeField] AudioClip maintheme;
    [SerializeField] AudioSource sound;
    [HideInInspector]
    private bool isPlaySound; //Update this later

    private void Start()
    {
        DecidePlaySound();
    }
    void DecidePlaySound()
    {
        sound.Play();
    }
}
