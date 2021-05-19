using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    bool isFullScreen;
    public AudioMixer am;

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void SetVolume(float sliderValue)
    {
        am.SetFloat("volume", sliderValue*70 - 50);
        Debug.Log(sliderValue);
    }
}
