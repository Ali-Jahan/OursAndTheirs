using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnActiveOnTrigger : MonoBehaviour
{
    public GameObject toTurnOn;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            toTurnOn.SetActive(true);
        }
    }
}
