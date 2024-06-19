using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float moveInput;
    public float checkRadius;

    private bool facingRight = true;
    private bool isGrounded = true;
    private bool hitCeil;

    public Transform groundCheck;
    public Transform ceilCheck;
    
    public LayerMask whatisGround;
    public LayerMask whatisCeil;

    public Animator animator;

    public BoxCollider2D collision;

    public Rigidbody2D rb;

    void FixedUpdate()
    {
        hitCeil = Physics2D.OverlapCircle(ceilCheck.position, checkRadius, whatisCeil);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisGround);

        animator.SetBool("isGrounded", isGrounded);

        moveInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(moveInput));

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (hitCeil && !isGrounded)
        {
            collision.enabled = false;
        }
        else if (isGrounded)
        {
            collision.enabled = true;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }

        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0);
    }
}
