using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSave : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private TextMeshProUGUI volumeText = null;

    private float volume;

    public void Awake()
    {
        // loads set volume
        volumeSlider.value = PlayerPrefs.GetFloat("Game Volume", volume);
    }

    public void SetVolume(float volume)
    {
        // changes volume of the game
        AudioListener.volume = volume;
        volumeText.text = (volume * 100).ToString("0");

        // sets volume so it can be saved
        PlayerPrefs.SetFloat("Game Volume", AudioListener.volume);
    }
}
