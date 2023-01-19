using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float jumpStrength;
    public float moveSpeed;
    public bool IsGrounded;
    public bool IsAlive = true;

    private PlayerInput _playerInput;
    private float _inputX;
    private bool _goingRight = true;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(IsAlive)
        {
            _inputX = context.ReadValue<Vector2>().x;
            // Rotate the character if turning
            if ((_inputX > 0 && !_goingRight) || (_inputX < 0 && _goingRight))
            {
                transform.rotation *= Quaternion.Euler(0, 180, 0);
                _goingRight = !_goingRight;
            }
        }
    }


    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded && IsAlive)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpStrength);
            IsGrounded = false;
        }
    }
    
    public void OnGround()
    {
        IsGrounded = true;
    }

    public void OffGround()
    {
        IsGrounded = false;
    }

    public void OnGameOver()
    {
        IsAlive = false;
    }
    
    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        if(IsAlive)
        {
            Move();
        }
    }

    void Move()
    {
        myRigidBody.velocity = new Vector2(_inputX * moveSpeed, myRigidBody.velocity.y);
    }
}
