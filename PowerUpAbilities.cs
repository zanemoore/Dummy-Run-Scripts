using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAbilities : PowerUp
{
    /// Level 2
    public static void JumpPowerUp()
    {
        PlayerMovement.jumpHeight *= 4f;
        PlayerMovement.gravity += 8f;
    }

    /// Level 3
    public static void SpeedPowerUp()
    {
        PlayerMovement.jumpHeight *= 4f;
        PlayerMovement.walkSpeed *= 2f;
        PlayerMovement.runSpeed *= 2f;
    }
}
