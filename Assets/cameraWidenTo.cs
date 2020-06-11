using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class cameraWidenTo : MonoBehaviour
{
    public float targetSize = 44f;
    public float multiplier = 1f;
    public float returnDelay = 5f;
    public float returnMultiplier = 1f;
    private GameObject camObj;
    private float initial;
    private bool ret = false;
    private Camera cam;

    private bool canDo = true;
    // Start is called before the first frame update
    void Start()
    {
        // string camTag;
        // var first = PhotonNetwork.PlayerList[0].UserId;
        // if (PhotonNetwork.LocalPlayer.UserId == first)
        // {
        //     camTag = "cam1";
        // }
        // else
        // {
        //     camTag = "cam2";
        // }
        // // camObj = GameObject.FindGameObjectWithTag(camTag);
        // // cam = camObj.GetComponent<Camera>();
        cam = Camera.main;
        initial = cam.orthographicSize;
        GameObject.FindWithTag("Player").GetComponent<multitargetcamera>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.orthographicSize < targetSize && !ret)
        {
            cam.orthographicSize += multiplier * Time.deltaTime;
        } else 
        if (cam.orthographicSize >= targetSize && canDo)
        {
            canDo = false;
            StartCoroutine(returnToInitial(returnDelay));
        }
        else 
        if (cam.orthographicSize > initial && ret)
        {
            cam.orthographicSize -= returnMultiplier * Time.deltaTime;
            if (cam.orthographicSize <= initial)
            {
                GameObject.FindWithTag("Player").GetComponent<multitargetcamera>().enabled = true;
                ret = false;
            }
        }
    }

    IEnumerator returnToInitial(float ms)
    {
        yield return new WaitForSeconds(ms);
        ret = true;
    }
}
