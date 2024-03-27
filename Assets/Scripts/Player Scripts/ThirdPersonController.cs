using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonController : MonoBehaviour
{
    // input fields
    private PlayerInputMaster _playerInput;
    private InputAction _move;
    
    // movement fields
    private Rigidbody _rb;
    [SerializeField] private float movementForce = 1f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float maxSpeed = 5f;
    private Vector3 _forceDirection = Vector3.zero;

    [SerializeField] private Camera playerCamera;

    private void Awake()
    {
        _rb = this.GetComponent<Rigidbody>();
        _playerInput = new PlayerInputMaster();
    }

    private void OnEnable()
    {
        _playerInput.Player.Jump.started += DoJump;
        _move = _playerInput.Player.Move;
        _playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Player.Jump.started -= DoJump;
        _playerInput.Player.Disable();
    }

    private void FixedUpdate()
    {
        _forceDirection += GetCameraRight(playerCamera) * (_move.ReadValue<Vector2>().x * movementForce);
        _forceDirection += GetCameraForward(playerCamera) * (_move.ReadValue<Vector2>().y * movementForce);
        
        _rb.AddForce(_forceDirection, ForceMode.Impulse);
        _forceDirection = Vector3.zero;

        if (_rb.velocity.y < 0f)
            _rb.velocity += Vector3.down * (Physics.gravity.y * Time.fixedDeltaTime);

        Vector3 horizontalVelocity = _rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            _rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * _rb.velocity.y;
        
        LookAt();
    }

    private void LookAt()
    {
        Vector3 direction = _rb.velocity;
        direction.y = 0f;

        if (_move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            this._rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            _rb.angularVelocity = Vector3.zero;
    }
    
    private Vector3 GetCameraForward(Camera camera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera camera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        if (IsGrounded())
        {
            _forceDirection += Vector3.up * jumpForce;
        }
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
            return true;
        else
            return false;
    }
}
