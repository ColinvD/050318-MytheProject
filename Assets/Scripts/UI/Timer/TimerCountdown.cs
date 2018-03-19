using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCountdown : MonoBehaviour {

    [SerializeField]
    private ChangeText timerText;
    [SerializeField]
    private bool start = true;
    [SerializeField]
    private int time = 0;
    [SerializeField]
    private int startTime = 120;

    private int timeSeconds;

    void Update()
    {
        if (start && timeSeconds <= 0)
        {
            StartCoroutine("CountDown");
            start = false;
        }
        if (time != 0 && timeSeconds > 0)
        {
            ChangeSecondsAmount(time);
            time = 0;
        } else if (time != 0 && timeSeconds <= 0)
        {
            time = 0;
        }
        if (timeSeconds < 0)
        {
            timeSeconds = 0;
            TextChange();
        }
    }

    private IEnumerator CountDown()
    {
        timeSeconds = startTime;
        while (timeSeconds > 0)
        {
            timeSeconds--;
            TextChange();
            yield return new WaitForSeconds(1);
        }
    }

    private void TextChange()
    {
        int minutes = timeSeconds / 60;
        int seconds = timeSeconds % 60;
        string extra = "0";
        string text;
        if (seconds < 10)
        {
            text = "" + minutes + ":" + extra + seconds;
        }
        else
        {
            text = "" + minutes + ":" + seconds;
        }
        timerText.Change(text);
    }

    private void ChangeSecondsAmount(int seconds)
    {
        timeSeconds += seconds;
    }
}
