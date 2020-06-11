using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addForceOnImpact : MonoBehaviour
{
    public string Tag = "bigBox";
    public Vector2 force;
    private bool on = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void stopForce()
    {
        on = false;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, rb.velocity.y);
        rb.angularVelocity *= 0;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Tag))
        {
            on = true;
            GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (on)
        // {
        //     GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        // }
    }
}
