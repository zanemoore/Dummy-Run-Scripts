using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SensitivitySave : MonoBehaviour
{
    [SerializeField] private Slider sensitivitySlider = null;
    [SerializeField] private TextMeshProUGUI sensitivityText = null;

    private float sensitivity;


    public void Start()
    {
        // loads set sensitivity
        sensitivitySlider.value = PlayerPrefs.GetFloat("Mouse Sensitivity", sensitivity);
    }

    public void SetSensitivity(float sensitivity)
    {
        // changes player mouse sensitivity
        PlayerLook.mouseSensitivity = sensitivity;
        sensitivityText.text = sensitivity.ToString("0.0");

        // sets sensitivity so it can be saved
        PlayerPrefs.SetFloat("Mouse Sensitivity", PlayerLook.mouseSensitivity);
    }
}
