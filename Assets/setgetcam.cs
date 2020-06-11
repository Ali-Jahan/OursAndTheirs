using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setgetcam : MonoBehaviour
{
    public GameObject mine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setCam(GameObject cam)
    {
        mine = cam;
    }

    public GameObject getCam()
    {
        return mine;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
