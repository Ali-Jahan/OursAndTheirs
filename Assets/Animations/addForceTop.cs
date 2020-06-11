using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addForceTop : MonoBehaviour
{
    public Vector2 force;
    public Vector2 forcePos;
    public string Tag;
    private Rigidbody2D rb;

    private bool stop = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Tag))
        {
            rb.isKinematic = false;
            rb.AddForceAtPosition(force, forcePos, ForceMode2D.Impulse);
            stop = false;
        }
    }

    //
    // void stopIt()
    // {
    //     StartCoroutine(stopAt(2));
    // }
    // IEnumerator stopAt(float seconds)
    // {
    //     yield return new WaitForSeconds(seconds);
    //     stop = true;
    // }
    void Update()
    {
        // if (!stop)
        // {
        //     rb.AddForceAtPosition(force, forcePos);
        // }
    }
}
