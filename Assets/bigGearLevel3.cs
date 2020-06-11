using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigGearLevel3 : MonoBehaviour
{
    public float maxXspeed = 10f;
    private bool turn = false;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bigGearCheck"))
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<ConstantForce2D>().enabled = true;
            GetComponent<AudioSource>().enabled = true;
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.x > maxXspeed)
        {
            rb.velocity = new Vector2(maxXspeed, rb.velocity.y);
        }
    }
}
