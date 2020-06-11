using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushPull : MonoBehaviour
{
    public LayerMask boxMask;
    public float distance = 1f;

    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);
        if (hit.collider && Input.GetKey(KeyCode.E) && hit.collider.gameObject.CompareTag("pushable"))
        {
            obj = hit.collider.gameObject;
            obj.GetComponent<FixedJoint2D>().enabled = true;
            obj.GetComponent<FixedJoint2D>().connectedBody = GetComponent<Rigidbody2D>();
        } else if (Input.GetKeyUp(KeyCode.E))
        {
            obj.GetComponent<FixedJoint2D>().enabled = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}
