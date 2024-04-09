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
    [SerializeField] Transform playerCamera; //Reference to the camera

    public float verticalInput; //Float for the vertical input
    public float horizontalInput; //Float for the horizontal input

    public bool jumpInput; //Bool for the jump input
    
    // Awake is called when the script instance is being loaded
    //Sets the references to the PlayerLocomotion and PlayerInteraction scripts
    private void Awake()
    {
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerInteraction = GetComponent<PlayerInteraction>();
        playerCamera = GameObject.FindWithTag("PCCamera").GetComponent<Camera>().transform;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
    //Handles the interaction input by calling the Interact method in the PlayerInteraction script
    private void HandleInteraction()
    {
        // Create a ray that starts at the camera's position and points in the direction the camera is facing
        Ray cameraRay = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit cameraHit;

        // Perform the raycast with a range of 20 units
        if (!Physics.Raycast(cameraRay, out cameraHit, 20f)) {
            Debug.Log("Camera ray hit nothing");
            return;
        }

        // Create a ray that starts at the player's position and points towards the point where the camera ray hit
        Vector3 playerToCameraHit = cameraHit.point - transform.position;
        Ray playerRay = new Ray(transform.position, playerToCameraHit);
        RaycastHit playerHit;

        // Check if the hit point is within a 120 degree cone in front of the player
        if (Vector3.Angle(transform.forward, playerToCameraHit) > 60f) return;

        // Perform the raycast
        if (!Physics.Raycast(playerRay, out playerHit, playerToCameraHit.magnitude)) {
            Debug.Log("Player ray hit nothing");
            return;
        }

        // Check if the object hit has the ObjectType component
        ObjectType objectType = playerHit.collider.gameObject.GetComponent<ObjectType>();
        if (objectType == null) return;

        int type = objectType.objectType;
        Debug.Log($"Object of type {type}");
        playerInteraction.Interact(type, playerHit.collider.gameObject);
    }
}