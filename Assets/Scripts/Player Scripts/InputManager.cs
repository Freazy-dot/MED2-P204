using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerInputMaster playerInput; //Reference to the PlayerInputMaster script
    PlayerLocomotion playerLocomotion; //Reference to the PlayerLocomotion script
    PlayerInteraction playerInteraction; //Reference to the PlayerInteraction script
    public Vector2 movementInput; //Vector2 for the movement input
    public Vector2 cameraInput; //Vector2 for the camera input

    public float cameraInputX; //Float for the camera input on the x axis
    public float cameraInputY; //Float for the camera input on the y axis

    public float verticalInput; //Float for the vertical input
    public float horizontalInput; //Float for the horizontal input

    public bool jumpInput; //Bool for the jump input
    
    // Awake is called when the script instance is being loaded
    //Sets the references to the PlayerLocomotion and PlayerInteraction scripts
    private void Awake()
    {
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerInteraction = GetComponent<PlayerInteraction>();
    }   

    //OnEnable is called when the object becomes enabled and active
    //Sets up the player input
    private void OnEnable()
    {
        if (playerInput == null)
        {
            playerInput = new PlayerInputMaster();

            playerInput.Player.Move.performed += i => movementInput = i.ReadValue<Vector2>();

            playerInput.Player.Move.canceled += i => movementInput = Vector2.zero;
            playerInput.Player.Look.performed += i => cameraInput = i.ReadValue<Vector2>();

            playerInput.Player.Interact.performed += i => HandleInteraction();

            playerInput.Player.Jump.performed += i => jumpInput = true;
        }

        playerInput.Enable();
    }
    //OnDisable is called when the behaviour becomes disabled
    //Disables the player input
    private void OnDisable()
    {
        playerInput.Disable();
    }
    //Handles all inputs
    //Calls the HandleMovementInput and HandleJumpingInput methods
    public void HandleAllInputs()
    {
       HandleMovementInput();
       HandleJumpingInput();
    }
    //Handles the movement input by setting the vertical and horizontal input to the y and x values of the movement input
    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;
    }
    //Handles the jumping input by calling the HandleJumping method in the PlayerLocomotion script
    private void HandleJumpingInput()
    {
        if (jumpInput)
        {
            jumpInput = false;
            playerLocomotion.HandleJumping();
        }
    }
<<<<<<< Updated upstream
    //Handles the interaction input by calling the Interact method in the PlayerInteraction script
    private void HandleInteraction()
=======

private void HandleInteraction()
>>>>>>> Stashed changes
    {
    // Create a ray that starts at the player's position and points forward
    Ray ray = new Ray(transform.position, transform.forward);
    RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, 5f))
        {
            // Check if the object hit has the ObjectType component
            ObjectType objectType = hit.collider.gameObject.GetComponent<ObjectType>();
            if (objectType != null)
            {
                int type = objectType.objectType;
                Debug.Log($"Object of type {type} is within 5 meters in front of the player");
                playerInteraction.Interact(type, hit.collider.gameObject);
            }
        }
    }
}