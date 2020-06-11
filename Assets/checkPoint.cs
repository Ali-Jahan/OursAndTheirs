using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    public bool active = false;

    public bool first = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deactive()
    {
        active = false;
    }

    public bool isActive()
    {
        return active;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && first)
        {
            var checkPoints = GameObject.FindGameObjectsWithTag("checkPoint");
            foreach (var c in checkPoints)
            {
                c.GetComponent<checkPoint>().deactive();
            }
            first = false;
            active = true;
        } 
    }
        
}
