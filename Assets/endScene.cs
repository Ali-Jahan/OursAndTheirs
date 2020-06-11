using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScene : MonoBehaviour
{
    public GameObject cutScene;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cutScene.SetActive(true);
        }
    }
}
