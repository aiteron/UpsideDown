using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public void SetStoryIsShowed()
    {
        PlayerPrefs.SetString("StoryIsShowed", "");
        PlayerPrefs.Save();
    }

    public void Awake()
    {
        if (PlayerPrefs.HasKey("StoryIsShowed"))
        {
            transform.gameObject.SetActive(false);
        }
    }
}
