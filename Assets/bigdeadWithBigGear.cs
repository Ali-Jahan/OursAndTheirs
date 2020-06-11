using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class bigdeadWithBigGear : MonoBehaviour
{
    public GameObject bigGear;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(GameObject.FindGameObjectWithTag("bigGear"));
        }
    }
}
