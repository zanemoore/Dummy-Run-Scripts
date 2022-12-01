using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPlatformAnimation : MonoBehaviour
{
    /// Level 2

    [SerializeField] private Animator animationControllerX;
    [SerializeField] private Animator animationControllerZ;
    [SerializeField] private Animator animationControllerReverseX;

    private void OnTriggerEnter(Collider other)
    {
        // plays animation when the player reaches a certain part of the level
        if(other.CompareTag("Player"))
        {
            animationControllerX.SetBool("platformMove", true);
            animationControllerZ.SetBool("platformMove", true);
            animationControllerReverseX.SetBool("platformMove", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // stops animation when the player reaches a certain part in the level
        if (other.CompareTag("Player"))
        {
            animationControllerX.SetBool("platformMove", false);
            animationControllerZ.SetBool("platformMove", false);
            animationControllerReverseX.SetBool("platformMove", false);
        }
    }
}
