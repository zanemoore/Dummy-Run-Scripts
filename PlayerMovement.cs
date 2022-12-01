using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform grounded;
    [SerializeField] private LayerMask groundedMask;
    [SerializeField] private float groundedDistance;

    bool isGrounded;

    public static float walkSpeed = 6f;
    public static float runSpeed = 8f;
    public static float jumpHeight = 2f;
    public static float gravity = -24f;

    Vector3 velocity;

    void Update()
    {
        // checks if player is on the ground
        isGrounded = Physics.CheckSphere(grounded.position, groundedDistance, groundedMask);

        // resets velocity and forces player on the ground
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float keyboardX = Input.GetAxis("Horizontal");
        float keyboardZ = Input.GetAxis("Vertical");

        // allows kepyboard inputs (WASD or arrow keys) to change direction of movement
        Vector3 movement = transform.right * keyboardX + transform.forward * keyboardZ;

        // allows player to move and controls the speed of walking

        if (Input.GetKey("left shift"))
        {
            // controls speed of running
            controller.Move(movement * runSpeed * Time.deltaTime);
        }
        else
        {
            // controls speed of walking
            controller.Move(movement * walkSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // when 'R' is pressed the game restarts
            TimerController.gameRestart = true;
            GameStateManager.NewGame();
        }

        // increases velocity as player falls
        velocity.y += gravity * Time.deltaTime;

        // allows player to fall
        controller.Move(velocity * Time.deltaTime);

        // allows player to jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
