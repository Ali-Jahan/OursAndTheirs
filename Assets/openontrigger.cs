using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openontrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<Animator>().SetBool("open", true);
        }
    }
}
