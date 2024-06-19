using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public static float moveInput;

    public float fireRate;
    public float nextFire = 0f;

    

    private bool facingRight = true;

    private bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatisGround;

    public Animator animator;

    public Transform FirePoint;
    public GameObject bulletPrefab;
 

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisGround);
        animator.SetBool("isGrounded", isGrounded);

        moveInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(moveInput));

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            Shoot();
            nextFire = Time.time + fireRate;
            
        }
        
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0);
    }
}
