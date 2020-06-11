using System;
using UnityEngine;
using System.Collections;

public class Move2Copy : MonoBehaviour
{
   
    public float speed = 8f;
    public float maxSpeed = 15f;
    public float jump = 20f;
    [Header("Orientation")]
    public bool orientToDirection = false;

    private Vector2 movement, cachedDirection;
    private float moveHorizontal;
    private float moveVertical;
    private Rigidbody2D rb;
    private bool jumping = false;

    private bool isRight = false;
    // Update gets called every frame
    void Update ()
    {	
        Debug.Log("hi");
        moveHorizontal = Input.GetAxis("Horizontal2");
        moveVertical = Input.GetAxis("Vertical2");
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(moveHorizontal, 0);
        
        if (moveHorizontal > 0)
        {
            isRight = true;
            transform.localScale = new Vector2(0.5f, transform.localScale.y);
        } else if (moveHorizontal < 0)
        {
            isRight = false;
            transform.localScale = new Vector2(-0.5f, transform.localScale.y);
        }
        else
        {
            if (isRight)
            {
                transform.localScale = new Vector2(0.5f, transform.localScale.y);
            }
            else
            {
                transform.localScale = new Vector2(-0.5f, transform.localScale.y);
            }
        }
    }



    // FixedUpdate is called every frame when the physics are calculated
    void FixedUpdate ()
    {
        // Apply the force to the Rigidbody2d
        rb.AddForce(movement * speed * 10f);

        if (Input.GetKey(KeyCode.RightShift))
        {
            if (!jumping)
            {
                rb.AddForce(new Vector2(0, jump * 10f));
                jumping = true;
            }
        }
        if (Math.Abs(rb.velocity.x) > maxSpeed)
        {
            if (rb.velocity.x > 0)
            {
                rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground") || other.gameObject.CompareTag("Player"))
        {
            jumping = false;
        }
    }
}