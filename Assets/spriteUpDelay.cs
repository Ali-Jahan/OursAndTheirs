using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class spriteUpDelay : MonoBehaviour
{
    public float delay = 2f;
    public float yOff = 0.3f;


    IEnumerator goUp(float ms)
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + yOff, 0);
        yield return new WaitForSeconds(ms);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - yOff, 0);
    }
    

    public void active()
    {
        StartCoroutine(goUp(delay));
    }
}
