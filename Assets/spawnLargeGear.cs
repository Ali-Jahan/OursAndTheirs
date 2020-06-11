using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class spawnLargeGear : MonoBehaviour
{
    public GameObject placeHolder;
    public GameObject toSpawn;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawn(placeHolder.gameObject.transform.position);
        }
    }

    public void spawn(Vector3 pos)
    {
        Instantiate(toSpawn, pos,
            Quaternion.identity);
    }
}
