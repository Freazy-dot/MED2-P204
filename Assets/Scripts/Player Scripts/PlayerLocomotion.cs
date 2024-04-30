using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager; //Reference to the InputManager script
    PlayerManager playerManager; //Reference to the PlayerManager script
    AnimationManager animationManager; //Reference to the AnimatorManager script
    SoundManager Soundman;

    [HideInInspector]public Vector3 moveDirection; //The direction the player is moving in
    private Vector3 spawnPosition; //The spawn position of the player
    CharacterController characterController; //Reference to the CharacterController component
    [SerializeField] private Transform playerCamera; //Reference to the camera object

    public float moveSpeed = 7; //The speed the player is moving at
    public float rotationSpeed = 15; //The speed the player is rotating at

    public float inAirTimer; //The time the player is in the air
    public float leapingVelocity; //The velocity of the player leaping
    public float fallingVelocity; //The velocity of the player falling

    public float rayCastHeightOffset = 0.5f; //The height offset of the raycast
    public float rayCastMaxDistance = 1; // The max distance of the raycast

    public LayerMask groundLayer; //The ground layer
    public LayerMask VRgroundLayer; //The VR ground layer

    public bool isGrounded; //Bool for if the player is grounded
    public bool isJumping; //Bool for if the player is jumping

    public float jumpHeight; //The height of the jump
    public float gravityIntensity = -15; //The intensity of the gravity

    // Awake is called when the script instance is being loaded
    //Sets the references to the PlayerManager and InputManager scripts
    public void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        inputManager = GetComponent<InputManager>();
        characterController = GetComponent<CharacterController>();
        animationManager = GetComponentInChildren<AnimationManager>();
        //Soundman = GameObject.FindGameObjectWithTag("AudioMan").GetComponent<SoundManager>();
        spawnPosition = transform.position;
        playerCamera = GameObject.FindWithTag("PCCamera").GetComponent<Camera>().transform;
    }


    //Handles all movement of the PC Player
    public void HandleAllMovement()
    {
        HandleFallingAndLanding();
        CheckGrounded();
        HandleMovement();
        HandleRotation();
        ReturnPlayer();
        
    }

    //Handles the movement of the player
    private void HandleMovement()
    {
        moveDirection = playerCamera.forward * inputManager.verticalInput;
        moveDirection = moveDirection + playerCamera.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection * moveSpeed;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = playerCamera.forward * inputManager.verticalInput;
        targetDirection = targetDirection + playerCamera.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

        transform.rotation = playerRotation;
    }

    private void HandleFallingAndLanding()
    {
        if (!isGrounded && !isJumping)
        {
            if (!playerManager.isInteracting)
            {
               animationManager.PlayTargetAnimation("Ammy|JumpDown", true);
                
            }
            inAirTimer = inAirTimer + Time.deltaTime;
            characterController.Move(-Vector3.up * fallingVelocity * inAirTimer * Time.deltaTime);
        }
    }

    private void CheckGrounded()
    {
        RaycastHit hit;
        Vector3 raycastOrigin = transform.position + Vector3.up * rayCastHeightOffset;

        if (Physics.Raycast(raycastOrigin, -Vector3.up, out hit, rayCastMaxDistance, groundLayer))
        {
            if (!isGrounded && !playerManager.isInteracting)
            {
                animationManager.PlayTargetAnimation("Ammy|JumpLand", true);
                //Soundman.playSFX("Land_player");
            }
            isGrounded = true;
            inAirTimer = 0;
        }
        else
        {
            isGrounded = false;
        }
        Debug.DrawRay(raycastOrigin, -Vector3.up * rayCastMaxDistance, Color.red);
    }

    private void ReturnPlayer()
    {
        RaycastHit hit;
        Vector3 raycastOrigin = transform.position + Vector3.up * rayCastHeightOffset;
        if (Physics.Raycast(raycastOrigin, -Vector3.up, out hit, rayCastMaxDistance, VRgroundLayer))
        {
            transform.position = spawnPosition;
        }    
        
    }

    public void HandleJumping()
    {
        if (isGrounded && !isJumping)
        {
            
            animationManager.animator.SetBool("isJumping", true);
            animationManager.PlayTargetAnimation("Ammy|JumpUp", true);
            isGrounded = false;
            float jumpVelocity = Mathf.Sqrt(-2 * gravityIntensity * jumpHeight);
            float verticalVelocity = jumpVelocity;

            float timeToPeak = Mathf.Abs(jumpVelocity / gravityIntensity);
            float timeToFall = Mathf.Sqrt(2 * jumpHeight / -gravityIntensity);
            float totalAirTime = timeToPeak + timeToFall;
            totalAirTime *= 0.2f;
            //Soundman.playSFX("Jump_player");

            StartCoroutine(JumpCoroutine(totalAirTime, verticalVelocity));
        }
    }

    IEnumerator JumpCoroutine(float totalAirTime, float verticalVelocity)
    {
        isJumping = true;
        isGrounded = false;
        float timeInAir = 0;

        while (timeInAir < totalAirTime)
        {
            
            
            float normalizedTime = timeInAir / totalAirTime;
            float jumpForce = Mathf.Lerp(jumpHeight, 0, normalizedTime);

            characterController.Move(Vector3.up * jumpForce * Time.deltaTime);

            timeInAir += Time.deltaTime;
            
            yield return null;
        }
        isJumping = false;
           
    }
}
