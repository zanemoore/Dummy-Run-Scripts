using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TextFade : MonoBehaviour
{
    [SerializeField] private TextMeshPro timerText;
    public static bool keyPressed = false;

    void Update()
    {
        // checks if 'W' has been pressed
        if(keyPressed == false)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                // starts coroutine that makes the text disappear when player presses 'W'
                keyPressed = true;
                StartCoroutine(FadeTextToZeroAlpha(1f, timerText));
            }
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshPro i)
    {
        // at the beginning of each level, the color of the text fades to transparent
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
