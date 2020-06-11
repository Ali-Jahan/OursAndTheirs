using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_script : MonoBehaviour
{
    [SerializeField]
    private Sprite switchOn;
    
    [SerializeField]
    private Sprite switchOff;
    
    [SerializeField]
    private GameObject door;
    
    private bool isOn = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = switchOff;
    }

    // Update is called once per frame
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = switchOn;
        isOn = true;
        door.GetComponent<openDoor>().open();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = switchOff;
        door.GetComponent<openDoor>().close();
        isOn = false;
    }

    public bool on()
    {
        return isOn;
    }
}
