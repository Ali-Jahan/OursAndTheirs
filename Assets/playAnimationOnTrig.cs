using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimationOnTrig : MonoBehaviour
{
    public GameObject toPlay;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            toPlay.GetComponent<Animator>().SetBool("open", true);
        }
    }
}
