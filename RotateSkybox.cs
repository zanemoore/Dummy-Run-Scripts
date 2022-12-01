using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    void Update()
    {
        // rotates skybox around the y-axis on the main menu
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 2);
    }
}
