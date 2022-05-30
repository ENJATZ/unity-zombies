using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timeCounter;

    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;
    private float startTime;

    void Start()
    {
        timeCounter.text = "Time: 00:00";
        BeginTimer();
    }
    public float GetElapsedTime() {
        return elapsedTime;
    }
    public void BeginTimer() {
        timerGoing = true;
        startTime = Time.time;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }
    private IEnumerator UpdateTimer() { 
        while (timerGoing) {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm': 'ss");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }
}
