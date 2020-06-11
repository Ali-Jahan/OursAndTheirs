using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject target;

    public float yOffset = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = target.GetComponent<Rigidbody2D>().position;
        transform.position = pos +  new Vector2(0, yOffset);
        // transform.position = new Vector3(pos.x, pos.y + yOffset, 0);
    }
}
