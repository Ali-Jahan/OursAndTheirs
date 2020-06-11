using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapplingHook : MonoBehaviour
{
    public float maxDistance = 10f;
    public LayerMask mask;
    private DistanceJoint2D joint;
    private Vector3 target;
    private RaycastHit2D hit;
    private Rigidbody2D rb;
    private void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            target = Camera.main.WorldToScreenPoint(Input.mousePosition);
            target.z = 0;
            hit = Physics2D.Raycast(transform.position, target - transform.position, maxDistance, mask);
            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                Debug.DrawRay(transform.position, target - transform.position, Color.red);
                joint.enabled = true;
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.distance = Vector2.Distance(target, transform.position);
                print(joint.distance);
                print(transform.position);
            } 
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            joint.enabled = false;
        }
    }
}
