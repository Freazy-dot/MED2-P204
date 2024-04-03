using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;
    PlayerManager playerManager;

    Vector3 moveDirection;
    [SerializeField]Transform cameraObject;
    Rigidbody PlayerRB;

    public float moveSpeed = 7;
    public float rotationSpeed = 15;

    public float inAirTimer;
    public float leapingVelocity;
    public float fallingVelocity;
    public float rayCastHeightOffset = 0.5f;
    public float rayCastMaxDistance = 1;
    public LayerMask groundLayer;

    public bool isGrounded;
    public bool isJumping;

    public float jumpHeight = 3;
    public float gravityIntensity = -15;
    public void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        inputManager = GetComponent<InputManager>();
        PlayerRB = GetComponent<Rigidbody>();
    }

    public void HandleAllMovement()
    {
        HandleFallingAndLanding();
        if (playerManager.isInteracting || isJumping)
            return;
        
        HandleMovement();
        HandleRotation();
    }
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
        

       if(Physics.SphereCast(rayCastOrigin, 0.5f, -Vector3.up, out hit, rayCastMaxDistance, groundLayer))
        {
            inAirTimer = 0;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        inAirTimer = inAirTimer + Time.deltaTime;
        PlayerRB.AddForce(transform.up * leapingVelocity);
        PlayerRB.AddForce(-Vector3.up * fallingVelocity * inAirTimer);
    }

   public void HandleJumping()
    {
        if(isGrounded)
        {
            float jumpingVelocity = Mathf.Sqrt(-2 * gravityIntensity * jumpHeight);
            Vector3 playerVelocity = moveDirection;
            playerVelocity.y = jumpingVelocity;
            PlayerRB.velocity = playerVelocity;
        }
    }

}
