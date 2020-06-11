using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public Transform[] backgrounds;

    private float[] pScales;

    public float smoothing = 1f;

    private Transform cam;

    private Vector3 prevCamPos;

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        prevCamPos = cam.position;
        pScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            pScales[i] = -backgrounds[i].position.z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float p = (prevCamPos.x - cam.position.x) * pScales[i];
            float targetX = backgrounds[i].position.x + p;
            Vector3 bTarget = new Vector3(targetX, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, bTarget, smoothing * Time.deltaTime);
        }

        prevCamPos = cam.position;
    }
}
