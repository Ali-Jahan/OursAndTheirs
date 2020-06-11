using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupLampLevel4 : MonoBehaviour
{
    public GameObject lamp;
    public GameObject text;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lamp.SetActive(true);
            text.SetActive(true);
            Destroy(gameObject);
        }
    }
}
