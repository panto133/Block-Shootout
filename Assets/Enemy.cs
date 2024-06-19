using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private float playerMoveInput;

    private GameObject target;
    private Vector2 targetPosition;
    private Rigidbody2D rb;

    GameObject player;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        
        playerMoveInput = player.GetComponent<PlayerMovement>().moveInput;
        targetPosition = target.transform.position;
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(playerMoveInput * speed, rb.velocity.y);

        if(transform.position.x - targetPosition.x > 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }  
    }  
}
