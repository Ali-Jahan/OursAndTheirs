using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateHex : MonoBehaviour
{
    public float rotSpeed = 5f;

    public bool fromStart = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void startSpinning()
    {
        fromStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fromStart)
        {
            transform.Rotate(new Vector3(0,0,rotSpeed));  
        }      
    }
}
