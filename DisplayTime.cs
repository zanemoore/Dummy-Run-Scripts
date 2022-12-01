using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class DisplayTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    public void Awake()
    {
        // displays completion time on game over screen
        timerText.text = PlayerPrefs.GetString("Player Time Text");
    }
}

