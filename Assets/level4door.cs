using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level4door : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door.GetComponent<Animator>().SetBool("open", true);
        }
    }
}
