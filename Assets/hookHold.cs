using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookHold : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("saw"))
        {
            other.gameObject.GetComponent<Animator>().enabled = false;
            GetComponent<Animator>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
