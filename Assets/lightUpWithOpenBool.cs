using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightUpWithOpenBool : MonoBehaviour
{
    public GameObject toOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toOpen.GetComponent<buttonOpenWithBox>().open)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
