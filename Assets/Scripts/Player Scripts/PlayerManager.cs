using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    InputManager inputManager; //Reference to the InputManager script
    CameraManager cameraManager; //Reference to the CameraManager script
    PlayerLocomotion playerLocomotion; //Reference to the PlayerLocomotion script
    Animator animator;
    

    public bool isInteracting;

    // Awake is called when the script instance is being loaded
    //Sets the references to the InputManager, CameraManager and PlayerLocomotion scripts
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();  
        inputManager = GetComponent<InputManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        
    }

    // Update is called once per frame
    //Handles all inputs
    private void Update()
    {
        inputManager.HandleAllInputs();

        
    }
    //FixedUpdate is called every fixed framerate frame
    //Handles all movement
    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }
    //LateUpdate is called every frame, if the Behaviour is enabled
    //Handles all camera movement
    private void LateUpdate()
    {
        cameraManager.HandleAllCameraMovement();

        isInteracting = animator.GetBool("isInteracting");
        playerLocomotion.isJumping = animator.GetBool("isJumping");
        animator.SetBool("isGrounded", playerLocomotion.isGrounded);
    }

}
