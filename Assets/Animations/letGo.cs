using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letGo : MonoBehaviour
{
    public float playbackSpeed = 0.4f;
    public GameObject toRelease;
    public string Tag = "saw";
    private Animator anim;

    public AudioClip aud;
    // Start is called before the first frame update
    void Start()
    {
        anim = toRelease.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("yo");
        if (other.gameObject.CompareTag(Tag))
        {
            // if (toRelease.GetComponent<AudioSource>())
            // {
            //     toRelease.GetComponent<AudioSource>().loop = true;
            //     toRelease.GetComponent<AudioSource>().Play();
            // }
            anim.speed = playbackSpeed;
            anim.SetBool("open", true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(KeyCode.L))
        // {
        //     anim.speed = playbackSpeed;
        //     anim.SetBool("open", true);
        // }
    }
}
