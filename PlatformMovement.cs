using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    /// Level 2

    [SerializeField] private GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        // allows player to stand on the platform while it's moving
        if (other.CompareTag("Player"))
        {
            Player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // allows player to jump from the moving platform
        if (other.CompareTag("Player"))
        {
            Player.transform.parent = null;
        }
    }
}
