using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager; //Reference to the InputManager script
    PlayerManager playerManager; //Reference to the PlayerManager script

    Vector3 moveDirection; //The direction the player is moving in
    Vector3 playerVelocity; //The velocity of the player
    [SerializeField]Transform cameraObject; //Reference to the camera object
    [SerializeField]Rigidbody PlayerRB; //Reference to the rigidbody component
   

    public float moveSpeed = 7; //The speed the player is moving at
    public float rotationSpeed = 15; //The speed the player is rotating at

    public float inAirTimer; //The time the player is in the air
    public float leapingVelocity; //The velocity of the player leaping
    public float fallingVelocity; //The velocity of the player falling
    public float rayCastHeightOffset = 0.5f; //The height offset of the raycast
    public float rayCastMaxDistance = 1; // The max distance of the raycast
    public LayerMask groundLayer; //The ground layer

    public bool isGrounded; //Bool for if the player is grounded
    public bool isJumping; //Bool for if the player is jumping

    public float jumpHeight = 3; //The height of the jump
    public float gravityIntensity = -15; //The intensity of the gravity

    // Awake is called when the script instance is being loaded
    //Sets the references to the PlayerManager and InputManager scripts
    public void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        inputManager = GetComponent<InputManager>();
        PlayerRB = GetComponent<Rigidbody>();
        
    }
    //Handles all movement of the PC Player
    public void HandleAllMovement()
    {
        HandleFallingAndLanding();
        HandleMovement();
        HandleRotation();
    }
    //Handles the movement of the player
    private void HandleMovement()
    {
       
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection * moveSpeed;

        Vector3 movementVelocity = moveDirection;
        PlayerRB.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput;
        targetDirection.Normalize();    
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }

    private void HandleFallingAndLanding()
    {
        RaycastHit hit;
        Vector3 rayCastOrigin = transform.position;
        rayCastOrigin.y = rayCastOrigin.y + rayCastHeightOffset;

        if (!isGrounded && !isJumping)
            { 
            inAirTimer = inAirTimer + Time.deltaTime;
            PlayerRB.AddForce(transform.up * leapingVelocity);
            PlayerRB.AddForce(-Vector3.up * fallingVelocity * inAirTimer);
            }
        if (Physics.SphereCast(rayCastOrigin, 0.5f, -Vector3.up, out hit, rayCastMaxDistance, groundLayer))
        {
            inAirTimer = 0;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

       
    }

   public void HandleJumping()
    {
        if (isGrounded)
        StartCoroutine(JumpEvent());
    }

    IEnumerator JumpEvent()
    {
        PlayerRB.velocity = new Vector3(PlayerRB.velocity.x, 0, PlayerRB.velocity.z);
        float jumpVelocity = Mathf.Sqrt(-2 * gravityIntensity * jumpHeight);
        PlayerRB.AddForce(transform.up * jumpVelocity, ForceMode.VelocityChange);
        isGrounded = false;
        isJumping = true;
        yield return new WaitForSeconds(0.5f);
        isJumping = false;
    }

}
