using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    private Rigidbody2D rb;
    public float goUpForce = 5f;
    private bool canGo = false;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // foreach (var g in GetComponents<EdgeCollider2D>())
        // {
        //     g.enabled = true;
        // }
        if (other.gameObject.CompareTag("Player"))
        {
            anim = other.gameObject.GetComponent<Animator>();
            rb = other.gameObject.GetComponent<Rigidbody2D>();
            other.gameObject.GetComponent<Animator>().SetBool("fall", false);
            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // foreach (var g in GetComponents<EdgeCollider2D>())
        // {
        //     g.enabled = true;
        // }
        if (other.gameObject.CompareTag("Player"))
        {
            
            canGo = true;
            other.GetComponent<Move2>().reallyFalling = false;
            other.gameObject.GetComponent<Animator>().SetBool("fall", false);
            rb = other.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        canGo = false;
        anim.SetBool("climb", false);
        other.GetComponent<Move2>().reallyFalling = true;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     foreach (var g in GetComponents<EdgeCollider2D>())
        //     {
        //         g.enabled = false;
        //     }
        // }
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        if (canGo)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector2(0, 0);
                anim.speed = 3;
                rb.velocity = new Vector2(0, 10);
                anim.SetBool("climb", true);
            } else if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector2(0, 0);
                rb.velocity = new Vector2(0, -10);
                anim.speed = 3;
                anim.SetBool("climb", true);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                anim.SetBool("climb", false);
            }
            // rb.velocity = new Vector2(rb.velocity.x, moveVertical * goUpForce * 10f);
            // //rb.AddForce(new Vector2(0, moveVertical * goUpForce * 10f));
            // if (moveVertical == 0)
            // {
            //     rb.velocity = new Vector2(rb.velocity.x, 0);
            // }
        }
    }
}
