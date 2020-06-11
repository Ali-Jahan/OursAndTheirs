using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushSomeObject : MonoBehaviour
{
    public GameObject obj;
    public Vector2 force;
    public bool widenCamAfterForce = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = obj.GetComponent<Rigidbody2D>();
    }

    public void push()
    {
        rb.AddForce(force);
        if (widenCamAfterForce)
        {
            GetComponent<cameraWidenTo>().enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
