using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private GameObject powerUp;
    [SerializeField] private GameObject pickupEffect;
    [SerializeField] private AudioClip powerUpSound;
    
    void OnTriggerEnter(Collider other)
    {
        // checks if the player collides with the power up
        if (other.CompareTag("Player"))
        {
            // picks up power up
            PickUp();

            // plays power up sound
            AudioSource.PlayClipAtPoint(powerUpSound, transform.position, 1.0f);

            if(powerUp.name == "Jump Power Up")
            {
                // activates jump power up
                PowerUpAbilities.JumpPowerUp();
            }

            if (powerUp.name == "Speed Power Up")
            {
                // activates speed power up
                PowerUpAbilities.SpeedPowerUp();
            }
        }
    }

    private void PickUp()
    {
        // applies effect to power up on pickup
        Instantiate(pickupEffect, transform.position, transform.rotation);

        // destroys power up
        powerUp.SetActive(false);
    }
}
