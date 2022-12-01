using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FPSToggle : MonoBehaviour
{
    [SerializeField] private Toggle toggleFPS;
    [SerializeField] private GameObject displayFPS;


    private void Awake()
    {
        // displays fps counter if toggle is on
        if ((PlayerPrefs.GetInt("Toggle FPS") == 1))
        {
            toggleFPS.isOn = true;
        }
        else
        {
            toggleFPS.isOn = false;
        }
    }

    private void Update()
    {
        // allows for fps toggle to be saved
        if (toggleFPS.isOn == true)
        {
            PlayerPrefs.SetInt("Toggle FPS", 1);
            displayFPS.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("Toggle FPS", 0);
            displayFPS.SetActive(false);
        }
    }
}
