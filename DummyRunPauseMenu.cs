using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DummyRunPauseMenu : MonoBehaviour
{
    // button actions on the pause menu

    [SerializeField] private GameObject pauseMenuUI;
    public static bool gamePaused = false;

    public void Update()
    {
        // pauses the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameStateManager.ResumeGame();
    }

    public void PauseGame() 
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        Cursor.lockState = CursorLockMode.None;
        GameStateManager.PauseGame();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        gamePaused = false;
        TimerController.gameRestart = true;
        GameStateManager.NewGame();
    }

    public void QuitToMenu()
    {
        gamePaused = false;
        Cursor.lockState = CursorLockMode.None;
        GameStateManager.QuitToMenu();
    }
}
