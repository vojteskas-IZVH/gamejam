using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public Animator animator;

    private PlayerInput _playerInput;
    private float _inputX;
    private bool _goingRight = true;
    private bool _isJumping = false;
    private bool _isFalling = false;
    private bool _attack = false;
    private static readonly int animatorSpeedKey = Animator.StringToHash("Speed");
    private static readonly int animatorIsJumpingKey = Animator.StringToHash("IsJumping");
    private static readonly int animatorIsFallingKey = Animator.StringToHash("IsFalling");
    private static readonly int animatorSwordSwingKey = Animator.StringToHash("SwordSwing");

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

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _attack = !_attack;
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
            var velocity = _inputX * moveSpeed;
            Move(velocity);

            animator.SetFloat(animatorSpeedKey, Mathf.Abs(velocity));
            animator.SetBool(animatorIsJumpingKey, myRigidBody.velocity.y > 0);
            animator.SetBool(animatorIsFallingKey, myRigidBody.velocity.y < 0);
            animator.SetBool(animatorSwordSwingKey, _attack);
        }
    }

    void Move(float velocityX)
    {
        myRigidBody.velocity = new Vector2(velocityX, myRigidBody.velocity.y);
    }
}
