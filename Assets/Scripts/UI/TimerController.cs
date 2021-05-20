using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    private TimeSpan timePlaying;
    private bool timerGoing;
    private float elapsedTime;

    private string showTimer;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        BeginTimer();
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }    

    public string GetShowTime()
    {
        return showTimer;
    }

    public float GetFloatTime()
    {
        return elapsedTime;
    }

    private IEnumerator UpdateTimer()
    {
        while(timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            showTimer = timePlaying.ToString("mm':'ss");

            yield return null;
        }
    }
}
