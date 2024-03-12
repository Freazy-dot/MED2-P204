using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float playerMovementSpeed = 1f;
    private PlayerInputMaster controls;
    private Vector3 velocity;
    private float gravity = -9.81f; // more or less equal to earth's gravity
    private Vector2 move;
    [SerializeField]float jumpHeight = 2.4f;
    private CharacterController controller;

    public Transform ground;
    public float distanceToGround = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    private void Awake()
    {
        controls = new PlayerInputMaster();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Gravity();
        PlayerMove();
        Jump();
    }

    private void Gravity()
    {
        isGrounded = Physics.CheckSphere(ground.position, distanceToGround, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // arbitrary value; makes the player jump up slightly after hitting the ground. Can be turned into a Serialized variable later.
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void PlayerMove()
    {
        move = controls.Player.Move.ReadValue<Vector2>();

        Vector3 movement = (move.y * transform.forward) + (move.x * transform.right);
        controller.Move(movement * (playerMovementSpeed * Time.deltaTime));
    }

    private void Jump()
    {
        if (controls.Player.Jump.triggered)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // idk why he wants the -2f, we can fix later, potentially integrate into grav or smthing idk
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
