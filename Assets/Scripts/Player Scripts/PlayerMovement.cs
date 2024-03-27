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
    private PlayerInputMaster _controls;
    private Vector3 _velocity;
    private readonly float _gravity = -9.81f; // more or less equal to earth's gravity
    [SerializeField] private float gravityMultiplier = 3.0f;
    
    private Vector2 _move;
    [SerializeField]float jumpHeight = 2.4f;
    private CharacterController _controller;

    public Transform ground;
    public float distanceToGround = 0.4f;
    public LayerMask groundMask;
    private bool _isGrounded;

    private void Awake()
    {
        _controls = new PlayerInputMaster();
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Gravity();
        PlayerMove();
        Jump();
    }

    private void Gravity()
    {
        _isGrounded = Physics.CheckSphere(ground.position, distanceToGround, groundMask);

        if (_isGrounded && _elocity.y < 0)
        {
            _velocity.y = -2f; // arbitrary value; makes the player jump up slightly after hitting the ground. Can be turned into a Serialized variable later.
        }

        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }

    private void PlayerMove()
    {
        _move = _controls.Player.Move.ReadValue<Vector2>();

        Vector3 movement = (_move.y * transform.forward) + (_move.x * transform.right);
        _controller.Move(movement * (playerMovementSpeed * Time.deltaTime));
    }

    private void Jump()
    {
        if (_controls.Player.Jump.triggered)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * _gravity); // idk why he wants the -2f, we can fix later, potentially integrate into grav or smthing idk
        }
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }
}
