using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    private bool isOpen = false;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void open()
    {
        anim.SetBool("open", true);
    }

    public void close()
    {
        anim.SetBool("open", false);
    }
}
