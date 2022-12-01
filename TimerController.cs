using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public static bool gameRestart = false;
    public float time;
    float minutes;
    float seconds;
    float milliseconds;

    static TimerController instance;

    public void Start()
    {
        // starts timer
        StartCoroutine("Timer");
    }

    public void StopTimer()
    {
        // stops timer
        StopCoroutine("Timer");
    }

    public void ResetTimer()
    {
        // resets timer
        time = Time.timeSinceLevelLoad;
        timerText.text = "00:00:00";
    }

    private void Awake()
    {
        // allows the timer to keep going between levels
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        // restarts timer when player resets the first level
        if (sceneName == "Dummy Run Level 1")
        {
            if (gameRestart == true)
            {
                StopTimer();
                ResetTimer();
                StartCoroutine("Timer");
            }
        }

        // destroys timer when player is not in a level
        if (sceneName == "Dummy Run Game Over Screen")
        {
            Destroy(gameObject);
        }
        else if(sceneName == "Dummy Run Main Menu")
        {
            Destroy(gameObject);
        }

        // sets completion time so it can be displayed on the game over screen
        PlayerPrefs.SetString("Player Time Text", timerText.text);
        PlayerPrefs.SetFloat("Player Time", time);
    }

    IEnumerator Timer()
    {
        // the time is converted into a readable format
        while(true)
        {
            time += Time.deltaTime;
            minutes = (int)(time / 60 % 60);
            seconds = (int)(time % 60);
            milliseconds = (int)((time - (int)time) * 100);

            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);

            yield return null;
        }
    }
}
