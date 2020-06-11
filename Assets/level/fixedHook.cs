using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class fixedHook : MonoBehaviour
{
    public float maxDist;
    public float rotateSpeed = 5;
    private bool isGrabbing;
    private GameObject[] hinges;

    private GameObject grabbed = null;
    // Start is called before the first frame update
    void Start()
    {
        hinges = GameObject.FindGameObjectsWithTag("hinge");
    }

    // Update is called once per frame
    void Update()
    {
        // make line
        LineRenderer lr = gameObject.GetComponent<LineRenderer>();
        lr.startColor = Color.black;
        lr.endColor = Color.black;
        lr.startWidth = 0.15f;
        lr.endWidth = 0.15f;
        
        // mouse stuff
        if (Input.GetMouseButtonDown(0))
        {
            isGrabbing = true;
        }
        
        if (Input.GetMouseButton(0))
        {
            lr.positionCount = 2;
            
            var closest = getClosest();
            if (isGrabbing)
            {
                grabbed = closest;
                lr.SetPosition(1, closest.transform.position);
                GetComponentInChildren<FixedJoint2D>().enabled = true;
                GetComponentInChildren<FixedJoint2D>().connectedBody = closest.GetComponent<Rigidbody2D>();
                
                    // -(new Vector2(
                    // grabbed.transform.position.x - transform.position.x,
                    // grabbed.transform.position.y - transform.position.y));
                // gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                isGrabbing = false;
            }
            GetComponentInChildren<FixedJoint2D>().connectedAnchor =
                -(new Vector2(grabbed.transform.position.x, grabbed.transform.position.y)
                  - new Vector2(transform.position.x, transform.position.y));
            lr.SetPosition(0, grabbed.transform.position);
            lr.SetPosition(1, transform.position);
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            lr.positionCount = 0;
            GetComponentInChildren<FixedJoint2D>().connectedBody = null;
            GetComponentInChildren<FixedJoint2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                                                                 // | RigidbodyConstraints2D.FreezeRotation;
        }

    }

    // get the closest object
    // inefficient - think about it later!
    private GameObject getClosest()
    {
        GameObject closest = null;
        float max = Mathf.Infinity;
        Vector3 pos = transform.position;

        foreach (var g in hinges)
        {
            float dist = (g.transform.position - pos).sqrMagnitude;
            if (dist < max)
            {
                closest = g;
                max = dist;
            }
        }

        if (max > maxDist)
        {
            Debug.Log(max);
            Debug.Log(maxDist + " AH");
            return null;
        }
        return closest;
    }
}
