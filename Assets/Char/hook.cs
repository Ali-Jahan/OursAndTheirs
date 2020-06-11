using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class hook : MonoBehaviour
{
    DistanceJoint2D rope;

    bool checker;
    
    void Start()
    {
        gameObject.AddComponent<LineRenderer>();
    }
    
    void Update()
    {
        // Detect mouse position
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Shot rope on mouse position
        if (Input.GetMouseButtonDown(0) && checker == true)
        {
            rope = gameObject.AddComponent<DistanceJoint2D>();
            rope.connectedAnchor = mousePos;

            checker = false;
        }
        
        // Destroy rope
        else if (Input.GetMouseButtonDown(0))
        {
            DestroyImmediate(rope);

            checker = true;
        }
    }
}