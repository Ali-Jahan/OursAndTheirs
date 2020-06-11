using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redEyeblueEye : MonoBehaviour
{
    public GameObject redEye;

    public GameObject blueEye;

    private bool RedOrNot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setRedOrNot(bool input)
    {
        RedOrNot = input;
        if (RedOrNot)
        {
            redEye.gameObject.transform.localScale = new Vector3(2, 2, 2);
            blueEye.gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
            blueEye.gameObject.transform.localScale = new Vector3(2, 2, 2);
            redEye.gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // if (RedOrNot)
        // {
        //     redEye.gameObject.transform.localScale = new Vector3(2, 2, 0);
        //     blueEye.gameObject.transform.localScale = new Vector3(0, 0, 0);
        // }
        // else
        // {
        //     blueEye.gameObject.transform.localScale = new Vector3(2, 2, 0);
        //     redEye.gameObject.transform.localScale = new Vector3(0, 0, 0);
        // }
    }
}
