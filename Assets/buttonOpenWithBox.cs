using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonOpenWithBox : MonoBehaviour
{
    public bool open = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("levitate"))
        {
            open = true;
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("levitate"))
        {
            open = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("levitate"))
        {
            open = false;
        }
    }
}
