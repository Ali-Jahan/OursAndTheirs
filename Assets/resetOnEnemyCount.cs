using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resetOnEnemyCount : MonoBehaviour
{
    public string TagToDieWith;
    public int healthVsEnemy = 20;
    private int damage = 0;
    private bool dead = false;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            damage += 1;
        }

        if (other.gameObject.CompareTag(TagToDieWith))
        {
            GetComponent<Animator>().SetBool("death", true);
            dead = true;
            GetComponent<Move2>().dead = true;
            StartCoroutine(die());
        }
    }

    private void Update()
    {
        if (damage > healthVsEnemy && !dead)
        {
            GetComponent<Animator>().SetBool("death", true);
            dead = true;
            GetComponent<Move2>().dead = true;
            StartCoroutine(die());
        }

    }
    
    IEnumerator die()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
