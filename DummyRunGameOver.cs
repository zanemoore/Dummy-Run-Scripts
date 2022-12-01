using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyRunGameOver : MonoBehaviour
{  
    // button actions on the game over screen

    public void QuitToMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        GameStateManager.QuitToMenu();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
