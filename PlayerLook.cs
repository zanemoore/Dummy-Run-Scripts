using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private float rotation = 0f;

    public static float mouseSensitivity = 2.5f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        if(Time.timeScale == 1)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            // allows mouse movements for vertical rotation
            rotation -= mouseY;
            transform.localRotation = Quaternion.Euler(rotation, 0f, 0f);

            // allows mouse movements for horizontal rotation
            playerBody.Rotate(Vector3.up * mouseX);
        }

        // limits vertical rotation so that the player is not able to look behind them without horizontal rotation
        rotation = Mathf.Clamp(rotation, -90f, 90f);
    }
}
