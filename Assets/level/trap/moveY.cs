using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveY : MonoBehaviour
{
    public float amount = 0f;
    public float speed = 0.3F;
    private Transform oldPos;
    private void Start()
    {
        oldPos = transform;
    }

    void Update()
    {
        if (Math.Abs(oldPos.position.y - transform.position.y) < Math.Abs(amount))
        {
            transform.position = Vector2.Lerp(transform.position, 
                new Vector2(transform.position.x, transform.position.y + amount), speed * Time.deltaTime);
        }
    }
}
