using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerInputMaster playerInput;

    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    public float verticalInput;
    public float horizontalInput;
    private void OnEnable()
    {
        if (playerInput == null)
        {
            playerInput = new PlayerInputMaster();

            playerInput.Player.Move.performed += i => movementInput = i.ReadValue<Vector2>();

            playerInput.Player.Move.canceled += i => movementInput = Vector2.zero;
            playerInput.Player.Look.performed += i => cameraInput = i.ReadValue<Vector2>();
        }

        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;
    }
}
