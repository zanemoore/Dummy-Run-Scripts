using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayFPS : MonoBehaviour
{
    public int avgFrameRate;
    public TextMeshProUGUI displayText;

    public void Update()
    {
        // displays average FPS
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        displayText.text = avgFrameRate.ToString() + " FPS";
    }
}
