using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goGreenForDelay : MonoBehaviour
{
    public float delay = 2f;
    private Color initial;

    private void Start()
    {
        initial = GetComponent<SpriteRenderer>().color;
    }
    
    IEnumerator goGreen(float ms)
    {
        GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(ms);
        GetComponent<SpriteRenderer>().color = initial;
    }

    public void active()
    {
        StartCoroutine(goGreen(delay));
    }
}
