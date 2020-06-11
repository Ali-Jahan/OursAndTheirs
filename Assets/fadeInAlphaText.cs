using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeInAlphaText : MonoBehaviour
{
    public Color target;
    private Text t;
    public float speed;

    private void Start()
    {
        t = GetComponent<Text>();
        t.color = Color.clear;
    }

    private void Update()
    {
        t.color = Color.Lerp(Color.clear, target, speed);
    }
}
