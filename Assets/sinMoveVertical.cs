using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class sinMoveVertical : MonoBehaviour
{
    public float speed = 5f;
    public float height = 0.5f;
    private Vector3 pos;
    public bool test = false;
    private void Start()
    {
        pos = GetComponent<Rigidbody2D>().transform.position;
    }
    
    void Update() {
        float newY = pos.y + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(pos.x, newY, pos.z);
        // transform.position = Vector3.Lerp(pos, new Vector3(pos.x, newY, pos.z), Time.deltaTime * 10 * speed);

    }
}
