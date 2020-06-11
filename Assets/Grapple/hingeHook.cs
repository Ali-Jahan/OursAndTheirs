using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEditor;
using UnityEngine;

public class hingeHook : MonoBehaviourPun
{
    public float maxDist;
    public float minDistance;
    public float rotateSpeed = 5;
    private bool isGrabbing;
    private GameObject[] hinges;
    private Animator anim;
    public GameObject toConnect;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        hinges = GameObject.FindGameObjectsWithTag("hinge");
    }

    // Update is called once per frame
    void Update()
    {
        // var second = PhotonNetwork.PlayerList[1].UserId;
        // if (PhotonNetwork.LocalPlayer.UserId.Equals(second))
        // {
        //     hook();
        // }
        hook();
    }

    void hook()
    {
        // make line
        LineRenderer lr = gameObject.GetComponent<LineRenderer>();
        lr.startWidth = 2;
        lr.endWidth = 1.5f;
        lr.startColor = Color.black;
        lr.endColor = Color.white;
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
            if (isGrabbing && getClosest() != null)
            {
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                lr.SetPosition(1, closest.transform.position);
                closest.GetComponentInChildren<HingeJoint2D>().connectedBody =
                    gameObject.GetComponent<Rigidbody2D>();
                isGrabbing = false;
                var dir = new Vector3(closest.transform.position.x, closest.transform.position.y, 0);
                dir = dir - new Vector3(transform.position.x, transform.position.y, 0);
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                anim.SetBool("fall", false);
                anim.SetBool("walk", false);
                anim.SetBool("swing", true);
            }
            else
            {
                anim.SetBool("swing", false);
            }

            var d = closest.transform.position - transform.position;
            // lr.SetPosition(0, transform.position + 0.2f * d);
            lr.SetPosition(0, toConnect.transform.position);
            
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            lr.positionCount = 0;
            // inefficient
            // fix later!
            foreach (var g in hinges)
            {
                g.GetComponentInChildren<HingeJoint2D>().connectedBody = null;
            }
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation
                                                                 | RigidbodyConstraints2D.FreezeRotation;
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
            anim.SetBool("fall", true);
            anim.SetBool("swing", false);
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

        if (max > maxDist || max < minDistance)
        {
            return null;
        }
        return closest;
    }
}
