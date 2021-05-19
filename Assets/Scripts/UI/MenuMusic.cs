using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Awake()
    {
        var notFirst = false;
        var other = GameObject.FindGameObjectsWithTag("Music");

        foreach (GameObject oneOther in other)
        {
            if (oneOther.scene.buildIndex == -1)
            {
                notFirst = true;
            }
        }

        if (notFirst == true)
        {
            Destroy(gameObject);
            GameObject.Find("MenuMusic").GetComponent<MenuMusic>().PlayMusic();
            return;
        }

        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
