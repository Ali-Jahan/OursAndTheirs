using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace network
{
    public class MainMenu : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject findFriendPanel = null;
        [SerializeField] private GameObject waitingStatusPanel = null;
        [SerializeField] private Text waitingStatusText = null;

        private bool isConnecting = false;
        // photon uses game version to check 
        private const string GameVersion = "1.0";
        private const int MaxPlayerPerRoom = 2;

        private void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        private void Start()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        public void FindFriend()
        {
            isConnecting = true;
            
            findFriendPanel.SetActive(false);
            waitingStatusPanel.SetActive(true);

            waitingStatusText.text = "Searching...";

            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                PhotonNetwork.GameVersion = GameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected to Master.");

            if (isConnecting)
            {
                PhotonNetwork.JoinRandomRoom();
            }
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            waitingStatusPanel.SetActive(false);
            findFriendPanel.SetActive(true);

            Debug.Log("Disconnected due to : (cause)");
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("No player waiting.");

            PhotonNetwork.CreateRoom(null, new RoomOptions {MaxPlayers = MaxPlayerPerRoom});
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Client successfully joined.");

            int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

            if (playerCount != MaxPlayerPerRoom)
            {
                waitingStatusText.text = "Waiting for a player.";
                Debug.Log("Client waiting for a friend.");
            }
            else
            {
                waitingStatusText.text = "Player found. ";
                Debug.Log("Match ready to begin.");
            }
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayerPerRoom)
            {
                PhotonNetwork.CurrentRoom.IsOpen = false;
                
                Debug.Log("Game is ready to begin.");
                waitingStatusText.text = "Player found.";
                // PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);
                if (PhotonNetwork.IsMasterClient)
                {
                    PhotonNetwork.LoadLevel("level2");
                }
                
            }
        }
    }
}

