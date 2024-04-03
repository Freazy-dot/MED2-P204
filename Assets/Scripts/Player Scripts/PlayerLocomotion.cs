using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;
    PlayerManager playerManager;

    Vector3 moveDirection;
    Vector3 playerVelocity;
    [SerializeField]Transform cameraObject;
    [SerializeField]Rigidbody PlayerRB;
   

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
        if (isJumping)
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
