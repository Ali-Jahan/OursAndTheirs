using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class levitate : MonoBehaviourPun
{
    public LayerMask boxMask;
    public float distance = 50f;
    public float yOff = 1f;
    public float xOff = 1f;
    public float yForce = 10f;
    private GameObject obj;
    public float amplitude = 2f;
    public float speed = 2f;
    private Rigidbody2D rb;
    private Bounds bounds;
    public bool canDo = true;
    public Transform JointToRotate;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // var first = PhotonNetwork.PlayerList[0].UserId;
        // if (PhotonNetwork.LocalPlayer.UserId.Equals(first))
        // {
        //     lev();
        // }
        lev();
    }

    private void lev()
    {
        var mousePosition = Input.mousePosition;
        
        Physics2D.queriesStartInColliders = false;
        var transformStart = transform.position + 
                             new Vector3(0, yOff, 0);
        //transform.localScale.x / Math.Abs(transform.localScale.x) * xOff
        var moveTo = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y , 0));
        var dir = (moveTo - transformStart).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transformStart, dir, 
            distance, boxMask);
        Debug.DrawRay(transformStart, dir * distance, Color.green);
        if (hit.collider && hit.collider.gameObject.CompareTag("levitate"))
        {
            if (Input.GetKey(KeyCode.F) && canDo)
            {
                obj = hit.collider.gameObject;
                print("levitate");
                rb = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                // rb.isKinematic = true;
                rb.velocity = Vector2.zero;
                var y = rb.transform.position.y + amplitude*Mathf.Sin(speed*Time.time);
                rb.transform.position = Vector3.Lerp(rb.transform.position, moveTo, speed * Time.deltaTime);
                rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y , 0);
            }
        }
    }
}
