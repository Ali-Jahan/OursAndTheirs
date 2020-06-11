using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playerNameInput : MonoBehaviour
{
    [SerializeField] private InputField nameInputField = null;
    [SerializeField] private Button continueButton = null;

    private const string PlayerPrefsNameKey = "PlayerName";
    private Button find = null;
    private void Start()
    {
        SetUpInputField();
        find = GameObject.FindGameObjectWithTag("findPlayer").GetComponent<Button>();
        find.interactable = false;
    }

    private void SetUpInputField()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefsNameKey))
        {
            return;
        }

        string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);

        nameInputField.text = defaultName;

        SetPlayerName(defaultName);
    }

    public void SetPlayerName(string name)
    {    
        // checking input name is not empty 
        // only interactable if Not empty
        continueButton.interactable = !string.IsNullOrEmpty(name);
        Debug.Log("set player name");
    }

    public void SavePlayerName()
    {
        string playerName = nameInputField.text;
            
        PhotonNetwork.NickName = playerName;
            
        PlayerPrefs.SetString(PlayerPrefsNameKey, playerName);
        Debug.Log("Saved player name.");
        find.interactable = true;
        GameObject.FindGameObjectWithTag("input").SetActive(false);
    }
}
