using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openAndHold : MonoBehaviour
{
    public GameObject opened;
    public float playbackSpeed = 0.4f;
    public Animator anim;
    private bool canDo = false;
    private showCamOnEnter s;
    public bool inputE = false;
    // Start is called before the first frame update
    void Start()
    {
        if (opened)
        {
            anim = opened.GetComponent<Animator>();
        }
        
        s = GetComponent<showCamOnEnter>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        canDo = true;
        if (!inputE)
        {
            anim.speed = playbackSpeed;
            anim.SetBool("open", true);
        }
        
        
        if (opened.GetComponent<rotateHex>())
        {
            opened.GetComponent<rotateHex>().startSpinning();
        }   
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("asdlkj");
        canDo = false;
        
        if (anim)
        {
            anim.speed = playbackSpeed;
            anim.SetBool("open", false);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        // if (s)
        // {
        //     s.Off();
        // }
        // if (GetComponent<showCamOnEnter>())
        // {
        //     GetComponent<showCamOnEnter>().Off();
        // }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
        if (inputE && canDo)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (s)
                {
                    s.On();
                }

                if (GetComponent<showCamOnEnter>())
                {
                    GetComponent<showCamOnEnter>().On();
                }
                if (GetComponent<pushSomeObject>())
                {
                    GetComponent<pushSomeObject>().push();
                }

                if (anim)
                {
                    anim.speed = playbackSpeed;
                    anim.SetBool("open", true);
                }
            }
        }
    }
}