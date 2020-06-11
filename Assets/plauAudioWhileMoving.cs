using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plauAudioWhileMoving : MonoBehaviour
{
    public AudioClip clip;

    private AudioSource _audioSource;

    private Rigidbody2D rb;

    public bool disabled = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.enabled = true;
    }

    public void end()
    {
        _audioSource.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (disabled)
        {
            end();
        }
    }
}
