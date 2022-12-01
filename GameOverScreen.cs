using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private string GameOverScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // loads game over screen and unlocks cursor
            SceneManager.LoadScene(GameOverScene);
            Cursor.lockState = CursorLockMode.None;
            GameStateManager.GameOver();
        }
    }
}
