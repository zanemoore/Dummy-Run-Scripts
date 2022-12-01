using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // sends player to the next level when entering the portal
            GameStateManager.NextLevel();
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
