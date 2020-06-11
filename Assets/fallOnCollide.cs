using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallOnCollide : MonoBehaviour
{
    public string Tag = "bigBox";
    public AudioClip crash;
    public float delay = 2f;

    private bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator fall()
    {
        yield return new WaitForSeconds(delay);
        GetComponent<addForceOnImpact>().stopForce();
        yield return new WaitForSeconds(delay);
        GetComponent<AudioSource>().enabled = false;
        GetComponent<Animator>().enabled = false;

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Tag))
        {
            
            hit = true;
            StartCoroutine(fall());
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
