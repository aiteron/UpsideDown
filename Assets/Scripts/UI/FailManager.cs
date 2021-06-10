using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailManager : MonoBehaviour
{
    //public bool IsDeathMenu;

    public GameObject failMenuUI;
    public AudioSource failSound;

    public void Fail()
    {
        if (!Settings.IsDeathMenu)
        {
            failSound.Play();
            Restart();
        }
        else
        {
            Time.timeScale = 0f;
            failMenuUI.SetActive(true);
            GameObject.Find("GameMusic").GetComponent<AudioSource>().Stop();
            failSound.Play();
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
