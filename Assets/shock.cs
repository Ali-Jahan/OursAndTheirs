using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shock : MonoBehaviour
{
    public float delay = 2f;
    public GameObject start;
    public GameObject end;
    public GameObject lamp;
    public GameObject target;
    private bool canDo = false;
    public Vector3 offset;
    
    private void Start()
    {
        lamp = GameObject.FindWithTag("lamp");
        start.transform.position = lamp.transform.position + offset;
        end.transform.position = target.transform.position;
    }

    void Update()
    {
        if (canDo)
        {
            start.transform.position = lamp.transform.position + offset;
            end.transform.position = target.transform.position;
        }
        
    }

    public void setTarget(GameObject t)
    {
        target = t;
        canDo = true;
        StartCoroutine(destroyAfterDelay(delay, t));
    }

    IEnumerator destroyAfterDelay(float ms, GameObject t)
    {
        yield return new WaitForSeconds(ms);
        Destroy(t);
        Destroy(gameObject);
    }
}
