using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killAllEnemies : MonoBehaviour
{
    public GameObject electricity;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Camera.main.GetComponent<Animator>().SetTrigger("shake");
            var enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach (var g in enemies)
            {
                var e = Instantiate(electricity, transform.position,
                    Quaternion.identity);
                e.GetComponent<shock>().setTarget(g.gameObject);
                e.GetComponent<shock>().lamp = this.gameObject;
                g.GetComponent<attackPlayer>().tagged = true;
            }

            var spawns = GameObject.FindGameObjectsWithTag("enemySpawn");
            foreach (var spawn in spawns)
            {
                spawn.SetActive(false);
            }
        }
    }
}
