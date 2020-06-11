using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EXPONENTIAL:
// Enemy speed increases exponentially every time step
public class attackPlayer : MonoBehaviour
{
    public float exponentialFactor = 1.2f;
    private GameObject player;
    public float maxDistance;
    public float initialSpeed = 0.5f;
    private float initialTime;
    public float yOff = 2f;
    public float timeStep = 120;
    public bool tagged = false;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        initialTime = Time.time;
    }

    private void Update()
    {
        var distance =
            Vector2.Distance(transform.position, player.transform.position);
        if (distance < maxDistance)
        {
            var target = player.transform.position + new Vector3(0, yOff, 0);
            transform.position =
                Vector2.MoveTowards(transform.position, target, initialSpeed);
            if (Time.time - initialTime > timeStep)
            {
                initialSpeed *= exponentialFactor;
                initialTime = Time.time;
            }
        }
    }
}
