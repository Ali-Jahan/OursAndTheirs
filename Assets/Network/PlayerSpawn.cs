using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefabRed = null;
    [SerializeField] private GameObject playerPrefabBlue = null;
    [SerializeField] private GameObject cam = null;

    public Vector3 player1;

    public Vector3 player2;
    // Start is called before the first frame update
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        var first = PhotonNetwork.PlayerList[0].UserId;
        Vector3 pos;
        string camTag;
        GameObject player;
        if (PhotonNetwork.LocalPlayer.UserId == first)
        {
            pos = new Vector3(0, 0, 0);
            player = PhotonNetwork.Instantiate(playerPrefabBlue.name, player1, Quaternion.identity);
            player.GetComponent<levitate>().enabled = true;
            player.GetComponent<redEyeblueEye>().setRedOrNot(false);
            Camera.main.GetComponent<multitargetcamera>().addTarget(player);
            camTag = "cam1";
        }
        else
        {
            pos = new Vector3(-2, 0, 0);
            player = PhotonNetwork.Instantiate(playerPrefabRed.name, player2, Quaternion.identity);
            player.GetComponent<hingeHook>().enabled = true;
            player.GetComponent<redEyeblueEye>().setRedOrNot(true);
            Camera.main.GetComponent<multitargetcamera>().addTarget(player);
            camTag = "cam2";    
        }
        // var player = PhotonNetwork.Instantiate(playerPrefab.name, pos, Quaternion.identity);
        // var thisCam =  PhotonNetwork.Instantiate(cam.name, pos, Quaternion.identity);
        // thisCam.gameObject.tag = camTag;
        // thisCam.GetComponent<cameraSmooth>().target = player.transform;
        // player.gameObject.GetComponent<setgetcam>().setCam(thisCam);
        // Camera.main.GetComponent<multitargetcamera>().enabled = true;
        
        level2check(player);
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    
    
    private void level2check(GameObject playerObj)
    {
        var first = PhotonNetwork.PlayerList[0].UserId;
        var second = PhotonNetwork.PlayerList[1].UserId;
        var sceneName = SceneManager.GetActiveScene().name;
        if (sceneName.Equals("level2"))
        {
            if (PhotonNetwork.LocalPlayer.UserId.Equals(first))
            {
                playerObj.GetComponent<levitate>().enabled = true;
            }
            if (PhotonNetwork.LocalPlayer.UserId.Equals(second))
            {
                playerObj.GetComponent<hingeHook>().enabled = true;
            }
        }
    }
    private void Update()
    {
        // if (Input.GetKey(KeyCode.R))
        // {
        //     if (PhotonNetwork.IsMasterClient)
        //     {
        //         PhotonNetwork.AutomaticallySyncScene = true;
        //         PhotonNetwork.DestroyAll();
        //         PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().name);
        //     }
        // }
    }
}
