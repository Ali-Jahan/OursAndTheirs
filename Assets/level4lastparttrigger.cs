using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level4lastparttrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamParent;
    public float cameraIncrease = 0.1f;
    private Camera mainCam;
    private float initialCameraSize;
    public List<GameObject> spawners;
    public float delay = 2f;
    private bool camExpanding = false;
    public float camSpeed = 1f;
    public float orthoSpeed = 1f;
    public AudioClip audio1;

    private void Start()
    {
        mainCam = Camera.main;
        initialCameraSize = mainCam.orthographicSize;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(reduceVo.StartFade(GetComponent<AudioSource>(), 10, 1));
            GetComponent<AudioSource>().PlayOneShot(audio1);
            player.GetComponent<Move2>().enabled = false;
            player.GetComponent<Animator>().SetBool("fall", false);
            player.GetComponent<Animator>().SetBool("walk", false);
            // mainCam.GetComponent<multitargetcamera>().enabled = false;
            mainCamParent.GetComponent<parallax>().enabled = false;
            mainCamParent.GetComponent<multitargetcamera>().enabled = false;
            camExpanding = true;
            foreach (var g in spawners)
            {
                g.SetActive(true);
            }
            // StartCoroutine(activateSpawners());
        }
    }
    
    
    IEnumerator activateSpawners()
    {
        yield return new WaitForSeconds(20);
        Application.Quit();
    }

    private void Update()
    {
        if (camExpanding)
        {
            mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize, 30f, Time.deltaTime * orthoSpeed);
            mainCamParent.transform.position =
                Vector3.Lerp(mainCamParent.transform.position,
                    new Vector3(860f, -17.5f, -61f), Time.deltaTime * camSpeed);
        }
    }
}
