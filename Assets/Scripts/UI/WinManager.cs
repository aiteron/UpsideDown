using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    [SerializeField] private GameObject winMenuUI;
    [SerializeField] private AudioSource winSound;
    [SerializeField] private GameObject doorUp;
    [SerializeField] private GameObject doorNormal;

    [SerializeField] private GameObject timeText;

    [SerializeField] private GameObject star2;
    [SerializeField] private GameObject star3;
    [SerializeField] private Sprite starFull;
    [SerializeField] private float perfectTime;

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
        TimerController.instance.EndTimer();
        timeText.GetComponent<TextMeshProUGUI>().text = "Время: " + TimerController.instance.GetShowTime();

        var scoreName = SceneManager.GetActiveScene().name + "Score";
        if (!PlayerPrefs.HasKey(scoreName))
            PlayerPrefs.SetInt(scoreName, 1);

        if (TimerController.instance.GetFloatTime() < perfectTime + 10)
        {
            star2.GetComponent<Image>().sprite = starFull;
            if (PlayerPrefs.GetInt(scoreName) < 2)
                PlayerPrefs.SetInt(scoreName, 2);
        }
        if (TimerController.instance.GetFloatTime() < perfectTime)
        {
            star3.GetComponent<Image>().sprite = starFull;
            if (PlayerPrefs.GetInt(scoreName) < 3)
                PlayerPrefs.SetInt(scoreName, 3);
        }

        PlayerPrefs.Save();

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
