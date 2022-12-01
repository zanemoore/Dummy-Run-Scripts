using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject powerUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // sends player back to start of level
            player.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();

            // reactivates powerup
            powerUp.SetActive(true);

            // resets movement to original values
            PlayerMovement.walkSpeed = 6f;
            PlayerMovement.runSpeed = 8f;

            PlayerMovement.jumpHeight = 2f;
            PlayerMovement.gravity = -24f;
        }
    }
}
