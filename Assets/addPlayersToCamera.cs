using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addPlayersToCamera : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Camera.main.GetComponent<multitargetcamera>().targets.Count < 2)
            {
                Camera.main.GetComponent<multitargetcamera>().addTarget(other.gameObject);
            }
        }
    }
}
