using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 10f;
    public float jumpSpeed = 3f;
    private Rigidbody2D rb;

    private bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        throw new NotImplementedException();
    }

    private void FixedUpdate()
    {
        charMove();
    }

    private void charMove()
    {
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        } else if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        } 
        if (Input.GetKey("space"))
        {
            if (!jump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                jump = true;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            jump = false;
        }
    }
}
