using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class springUp : MonoBehaviour
{
    private GameObject target;
    public GameObject illusion;
    public Vector2 force;
    public float turnOffPeriod = 2f;
    private bool canDo = false;
    private bool playerIsIn = false;

    IEnumerator switchOff(float ms)
    {
        canDo = false;
        yield return new WaitForSeconds(ms);
        canDo = true;
    }
    public void active()
    {
        addForce();

    }

    private void Update()
    {
        addForce();
    }

    public void addForce()
    {
        // canDo = true;
        // playerIsIn = true;
        if (canDo  && playerIsIn)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                target.GetComponent<Rigidbody2D>().AddForce(force);
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canDo = true;
            playerIsIn = true;
            target = other.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canDo = true;
            playerIsIn = true;
            target = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canDo = false;
            playerIsIn = false;
            target = null;
        }
        
    }
}
