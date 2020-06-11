using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reducebigGearVolume : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var g = GameObject.FindWithTag("bigGear");
            var audiosource = g.GetComponent<AudioSource>();
            StartCoroutine(reduceVo.StartFade(audiosource, 2f, 0));
        }
    }
}
