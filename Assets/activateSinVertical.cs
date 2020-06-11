using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateSinVertical : MonoBehaviour
{
    private bool open = true;
    private Animator anim;
    [SerializeField] public GameObject[] plugs;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        open = true;
        foreach (var plug in plugs)
        {
            if (!plug.GetComponent<buttonOpenWithBox>().open)
            {
                open = false;
            }
        }

        if (open)
        {
            anim.SetBool("open", true);
            // GetComponent<sinMoveVertical>().enabled = true;
        }
        else
        {
            
            anim.SetBool("open", false);
            // GetComponent<sinMoveVertical>().enabled = false;
        }
    }
}
