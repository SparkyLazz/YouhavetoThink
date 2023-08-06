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
    public Transform groundTransform;

    //Private Variables
    private float horizontal;
    private bool isFacingRight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        horizontalMove();
        verticalMove();
        Flip();
    }
    void horizontalMove()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
    }
    void verticalMove()
    {
        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, Jump);
        }
    }
    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundTransform.position, 0.1f, groundLayer);
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
