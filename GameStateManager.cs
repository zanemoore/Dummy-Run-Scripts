using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    // controls the state of the game

    [SerializeField] private List<string> levels = new List<string>();
    [SerializeField] private string SceneName;
    private int level = 1;

    public static bool gamePaused = false;

    private static GameStateManager instance;
    
    enum GAMESTATE
    {
        MAINMENU,
        PLAYING,
        PAUSED,
        GAMEOVER
    }

    private static GAMESTATE state;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this);
        }
    }

    public static void NewGame()
    {
        state = GAMESTATE.PLAYING;
        TextFade.keyPressed = false;
        PlayerMovement.jumpHeight = 2f;
        PlayerMovement.gravity = -24f;
        instance.level = 1;
        SceneManager.LoadScene(instance.levels[0]);
    }

    public static void NextLevel()
    {
        state = GAMESTATE.PLAYING;
        TextFade.keyPressed = false;
        PlayerMovement.jumpHeight = 2f;
        PlayerMovement.gravity = -24f;
        SceneManager.LoadScene(instance.levels[instance.level++]);
    }

    public static void ResumeGame()
    {
        state = GAMESTATE.PLAYING;
    }

    public static void PauseGame()
    {
        state = GAMESTATE.PAUSED;
    }

    public static void QuitToMenu()
    {
        instance.level = 1;
        SceneManager.LoadScene(0);
        state = GAMESTATE.MAINMENU;
    }

    public static void GameOver()
    {
        state = GAMESTATE.GAMEOVER;
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
