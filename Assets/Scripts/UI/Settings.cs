using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer am;

    public void SetVolume(float sliderValue)
    {
        am.SetFloat("volume", sliderValue*50 - 30);
        Debug.Log(sliderValue);
    }
}
