using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    [SerializeField] private GameObject winMenuUI;
    [SerializeField] private AudioSource winSound;
    [SerializeField] private GameObject doorUp;
    [SerializeField] private GameObject doorNormal;
    bool isWin = false;

    public void Update()
    {
        if (isWin)
            return;

        if (doorNormal.GetComponent<ExitNormalScript>().isOpen && doorUp.GetComponent<ExitUpScript>().isOpen)
        {
            Win();
        }
    }

    public void Win()
    {
        isWin = true;
        Time.timeScale = 0f;
        winMenuUI.SetActive(true);
        GameObject.Find("GameMusic").GetComponent<AudioSource>().Stop();
        winSound.Play();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuLevel");
    }
}
