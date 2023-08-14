using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public Rigidbody2D rb;
    public float Speed;
    public float Jump;

    [Header("Ground Settings")]
    public LayerMask groundLayer;
    public Transform groundCheckTransform;
    public Vector2 groundCheckBoxSize;


    //Private Variables
    private float horizontal;
    private bool isFacingRight;
    private bool jumpPressed;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {   
        horizontal = Input.GetAxisRaw("Horizontal");
        jumpPressed = Input.GetButtonDown("Jump");
        Flip();
        CheckGround();
        verticalMove();
    }
    private void FixedUpdate()
    {
        horizontalMove();
    }
    void horizontalMove()
    {
        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
    }
    void CheckGround()
    {
        isGrounded = Physics2D.BoxCast(
            groundCheckTransform.position,
            groundCheckBoxSize,
            0f,
            Vector2.down,
            0.1f, // Adjust this to your desired ground detection distance
            groundLayer
        );
    }
    void verticalMove()
    {
        if (isGrounded && jumpPressed)
        {
            rb.velocity = new Vector2(rb.velocity.x, Jump);
        }
    }
    void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
