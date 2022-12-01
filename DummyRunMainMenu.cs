using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyRunMainMenu : MonoBehaviour
{
    // button actions on the main menu screen 

    public void NewGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        GameStateManager.NewGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
