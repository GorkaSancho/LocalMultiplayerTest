using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 10f;
    [SerializeField] float jumpHeight = 5f;
    private Vector3 spawnPoint;
    private float _moveDir;
    private float _jumpYVel;
    private Vector3 _moveVel;
    Rigidbody2D _rigidbody2D;
    private bool IsGrounded;


    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        spawnPoint = transform.position;
    }

    void FixedUpdate()
    {
        Move();
    }
    public void OnJump()
    {
        if (IsGrounded)
        {
            _jumpYVel = CalculateJumpVel(jumpHeight);
            
            _moveVel = _rigidbody2D.linearVelocity;
            _moveVel.y = _jumpYVel;
            _rigidbody2D.linearVelocity = _moveVel;
        }
    }

    public void Move()
    {
        _moveVel = _rigidbody2D.linearVelocity;
        _moveVel.x = _moveDir * _moveSpeed;
        _rigidbody2D.linearVelocity = _moveVel;
    }
    public void OnMove(InputValue value) //Haurem de mirar si es adalt aball dreta esquerra
    {
        _moveDir = value.Get<Vector2>().x;
        //moveInput = value.Get<Vector2>();
    }
    public void OnRespawn()
    {
        if(spawnPoint != null)
        {
            transform.position = spawnPoint;
            _rigidbody2D.linearVelocity = Vector2.zero;    
        } 
    }
    private float CalculateJumpVel(float height)
    {
        return MathF.Sqrt((-2 * _rigidbody2D.gravityScale*Physics2D.gravity.y * height));
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        IsGrounded = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        IsGrounded = false;        
    }
}
