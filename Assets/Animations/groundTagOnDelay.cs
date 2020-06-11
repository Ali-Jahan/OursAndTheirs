using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundTagOnDelay : MonoBehaviour
{
    public string Tag = "ground";
    public string enterTag = "Player";
    public float delay = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator delayTag()
    {
        yield return new WaitForSeconds(delay);
        gameObject.tag = Tag;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(enterTag))
        {
            StartCoroutine(delayTag());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
