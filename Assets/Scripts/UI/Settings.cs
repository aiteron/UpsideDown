using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public static bool IsDeathMenu;
    public AudioMixer am;

    public void SetVolume(float sliderValue)
    {
        am.SetFloat("volume", sliderValue*50 - 50);
        Debug.Log(sliderValue);
    }

    public void IsAutorestartToggle()
    {
        IsDeathMenu = !IsDeathMenu;
    }
}
