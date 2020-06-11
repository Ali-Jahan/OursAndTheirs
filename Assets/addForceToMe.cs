using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addForceToMe : MonoBehaviour
{
    public AudioClip audio1;
    public float delay;
    public float speedLimit = 50f;
    private Rigidbody2D rb;
    private int camShakeCountMax = 10;
    private int counter = 0;
    private void Start()
    {
        StartCoroutine(roll(delay));
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator roll(float ms)
    {
        yield return new WaitForSeconds(ms);
        GetComponent<ConstantForce2D>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            if (GetComponent<AudioSource>())
            {
                if (counter <= camShakeCountMax)
                {
                    Camera.main.GetComponent<Animator>().SetTrigger("shake");
                }
                counter += 1;
                GetComponent<AudioSource>().enabled = true;
                if (counter == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(audio1);
                }
            }
        }
    }

    private void Update()
    {
        if (rb.velocity.x > speedLimit)
        {
            rb.velocity = new Vector2(speedLimit, rb.velocity.y);
        }
    }
}
