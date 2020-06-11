using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieUnderBox : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Math.Abs(rb.velocity.y) > 1)
            {
                other.GetComponent<Move2>().die();
            }
        }
        
    }
}
