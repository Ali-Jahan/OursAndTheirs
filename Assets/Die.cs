using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Die : MonoBehaviour
{
    private GameObject restart;
    // Start is called before the first frame update
    void Start()
    {
        restart = GameObject.FindGameObjectWithTag("restart");
        Camera.main.GetComponent<Animator>().SetBool("death", true);
        StartCoroutine(deadScreen(4));
        
    }

    IEnumerator deadScreen(float delay)
    {
        yield return new WaitForSeconds(delay);
        restart.GetComponent<RectTransform>().localScale = Vector3.one;
    }

    // var player = PhotonNetwork.Instantiate(playerPrefab.name, pos, Quaternion.identity);
    // Update is called once per frame
    void Update()
    {
        
    }
}
