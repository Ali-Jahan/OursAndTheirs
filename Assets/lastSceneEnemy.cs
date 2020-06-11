using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lastSceneEnemy : MonoBehaviour
{
    public GameObject canv;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemyLastScene"))
        {
            var spawners = GameObject.FindGameObjectsWithTag("lastSceneSpawner");
            var enemies = GameObject.FindGameObjectsWithTag("enemyLastScene");
            foreach (var g in spawners)
            {
                Destroy(g);
            }

            foreach (var g in enemies)
            {
                Destroy(g);
            }
            canv.SetActive(true);
        }
    }
}
