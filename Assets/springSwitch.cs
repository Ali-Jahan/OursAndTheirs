using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class springSwitch : MonoBehaviour
{
    public GameObject spring;
    [SerializeField] public GameObject[] lights;
    private bool canDo = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && canDo)
        {
            
            spring.gameObject.GetComponent<springUp>().active();
            foreach (var g in lights)
            {
                g.GetComponent<goGreenForDelay>().active();
            }

        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canDo = true;
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canDo = true;
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canDo = false;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        
    }
}
