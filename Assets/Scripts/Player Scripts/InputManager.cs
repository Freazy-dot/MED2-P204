using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerInputMaster playerInput; //Reference to the PlayerInputMaster script
    PlayerLocomotion playerLocomotion; //Reference to the PlayerLocomotion script
    AnimationManager animatorManager; //Reference to the AnimatorManager script
    PlayerInteraction playerInteraction; //Reference to the PlayerInteraction script

    public Vector2 movementInput; //Vector2 for the movement input
    public Vector2 cameraInput; //Vector2 for the camera input
    private float moveAmount; //Float for the move amount

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
        animatorManager = GetComponent<AnimationManager>();

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

            playerInput.Player.Interact.performed += i => playerInteraction.HandleInteraction();

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


        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount);

        
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
}