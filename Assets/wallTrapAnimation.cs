using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallTrapAnimation : MonoBehaviour
{
    public GameObject left;

    public GameObject right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        left.GetComponent<Animator>().enabled = true;
        right.GetComponent<Animator>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
