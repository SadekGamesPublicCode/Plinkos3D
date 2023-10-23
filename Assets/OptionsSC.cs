using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.UI;

public class OptionsSC : MonoBehaviour
{
    [SerializeField] Slider soundSlide;
    [SerializeField] Toggle soundFXToggle;
    [SerializeField] Toggle vibratesToggle;

    private int soundCur; 
    private int soundMax;
    private int soundMin;
    private bool isSoundFX; //Toggle soundFX
    private bool isVib; //Toggle Vibrations

    private string ratingLink = ""; //put published linnk of game here

    private void Start() => GetPlayerOptionSaves();

    private void GetPlayerOptionSaves() 
    {
        
    }
    public void AdjustVolume() 
    {

    }
    public void OnToggleFX() 
    {

    }
    public void OnToggleVibrates()
    {
        if(isVib == false)
        {
            isVib = false;
        }
        else
        {
            isVib = true;
        }

    }
    public void OnClearPlayerPrefs() => PlayerPrefs.DeleteAll();
    public void OnQuitGame() => Application.Quit();
} 
