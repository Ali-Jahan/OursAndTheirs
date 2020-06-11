using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onewayRed : MonoBehaviour
{
    private SpriteRenderer sp;

    public bool inputE = false;
    public Color cl = Color.red;
    private bool canDo = false;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canDo = true;
        }
        if (!inputE)
        {
            sp.color = cl;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canDo = true;
        }
        if (!inputE)
        {
            sp.color = cl;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inputE && canDo)
        {
            if (Input.GetKey(KeyCode.E))
            {
                sp.color = cl;
            }
        }
    }
}
