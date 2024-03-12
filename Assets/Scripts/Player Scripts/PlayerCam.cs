using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCam : MonoBehaviour
{
    private PlayerInputMaster controls; // allows us to use the PlayerInputMaster script here (new input system basically)
    [SerializeField] float mouseSensitivity = 100f;
    private Vector2 mouseLook;
    private float xRotation = 0f;
    [SerializeField] private Transform playerBody;

    private void Awake()
    {
        controls = new PlayerInputMaster();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        mouseLook = controls.Player.Look.ReadValue<Vector2>();

        float mouseX = mouseLook.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseLook.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    // next two methods enables and disables the 
    
    private void OnEnable() 
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
