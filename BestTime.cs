using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BestTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestText;
    public float time;
    float minutes;
    float seconds;
    float milliseconds;

    public void Awake()
    {
        // checks if there is a saved best time
        if (PlayerPrefs.HasKey("Best Time"))
        {
            Save();
        }
        else
        {
            // sets best time to newest completion time if there is no saved best time
            bestText.text = PlayerPrefs.GetString("Player Time Text");
            PlayerPrefs.SetFloat("Best Time", PlayerPrefs.GetFloat("Player Time"));
        }
    }

    public void ConvertBestTime()
    {
        time = PlayerPrefs.GetFloat("Best Time");

        // converts decimal time to mm:ss:ms
        minutes = (int)(time / 60 % 60);
        seconds = (int)(time % 60);
        milliseconds = (int)((time - (int)time) * 100);

        bestText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void Save()
    {
        float completionTime = PlayerPrefs.GetFloat("Player Time");
        float bestTime = PlayerPrefs.GetFloat("Best Time");

        // checks if the most recent completion time is faster than the best time
        if (completionTime < bestTime)
        {
            // overrides the best time with the most recent completion time
            PlayerPrefs.SetFloat("Best Time", PlayerPrefs.GetFloat("Player Time"));
            PlayerPrefs.Save();
            ConvertBestTime();
        }
        else
        {
            // displays best time if the most recent completion time is slower than best time
            ConvertBestTime();
        }
    }
}
