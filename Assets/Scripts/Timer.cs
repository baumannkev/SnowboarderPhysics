using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    public bool isFinished = false;
    public float timeElapsed;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (isFinished)
            return;

        timeElapsed = Time.time - startTime;
        
        int minutes = (int)(timeElapsed / 60);
        int seconds = (int)(timeElapsed % 60);
        int milliseconds = (int)((timeElapsed * 100) % 100);

        timerText.text = $"{minutes:00}:{seconds:00}.{milliseconds:00}";
    }

    public void Finish()
    {
        isFinished = true;
    }
}
