using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openButton : MonoBehaviour
{
    public GameObject opened;
    public float playbackSpeed = 0.4f;
    private Animator anim;
    private bool canDo = false;
    public bool inputE = false;

    private void Start()
    {
        anim = opened.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!inputE)
        {
            anim.speed = playbackSpeed;
            anim.SetBool("open", true);
        }
        canDo = true;
        if (opened.GetComponent<rotateHex>())
        {
            opened.GetComponent<rotateHex>().startSpinning();
        } 
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (!inputE)
    //     {
    //         anim.speed = playbackSpeed;
    //         anim.SetBool("open", true);
    //     }
    //     canDo = true;
    //     if (opened.GetComponent<rotateHex>())
    //     {
    //         opened.GetComponent<rotateHex>().startSpinning();
    //     } 
    // }

    // Update is called once per frame
    void Update()
    {
        if (inputE && canDo)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("asdljk");
                anim.speed = playbackSpeed;
                anim.SetBool("open", true);
            }
        }
    }
}
