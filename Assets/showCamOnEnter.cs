using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showCamOnEnter : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void On()
    {
        canvas.SetActive(true);
    }
    
    public void Off()
    {
        canvas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
