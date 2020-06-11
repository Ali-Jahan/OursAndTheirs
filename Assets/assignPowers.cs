// using System;
// using System.Collections;
// using System.Collections.Generic;
// using Photon.Pun;
// using UnityEngine;
//
// public class assignPowers : MonoBehaviourPun
// {
//     private bool charOn = false;
//
//     private GameObject temp = null;
//
//     public bool RedOrNot = true;
//
//     public bool test = false;
//     // Start is called before the first frame update
//     void Start()
//     {
//         
//     }
//
//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         print("entered");
//         if (other.gameObject.GetPhotonView().IsMine || test)
//         {
//             charOn = true;
//             temp = other.gameObject;
//         }
//     }
//
//     private void OnTriggerExit2D(Collider2D other)
//     {
//         if (other.gameObject.GetPhotonView().IsMine || test)
//         {
//             charOn = false;
//             temp = null;
//         }
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         // if (charOn)
//         // {
//         //     if (temp.gameObject.GetPhotonView().IsMine || test)
//         //     {
//         //         if (Input.GetKey(KeyCode.P))
//         //         {
//         //             if (RedOrNot)
//         //             {
//         //                 GameObject.FindWithTag("redEye").GetComponent<followPlayer>().target =
//         //                     temp.gameObject.transform;
//         //                 temp.gameObject.GetComponent<hingeHook>().enabled = true;
//         //                 PhotonNetwork.Destroy(gameObject);
//         //             }
//                     // else
//                     {
//                         
//                         // if (PhotonNetwork.IsMasterClient)
//                         // {
//                         //     GameObject.FindWithTag("blueEye").GetComponent<followPlayer>().target = PhotonNetwork.PlayerList[0]
//                         //         // temp.gameObject.transform;
//                         //     temp.gameObject.GetComponent<levitate>().enabled = true;
//                         //     PhotonNetwork.Destroy(gameObject);
//                         // }
//                         
//                     }
//                 }
//             }
//         }
//     }
// }
