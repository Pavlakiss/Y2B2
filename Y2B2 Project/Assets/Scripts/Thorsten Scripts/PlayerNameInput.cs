using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class PlayerNameInput : MonoBehaviour
{
    public PlayerNames playernames;
    //public PhotonNetwork.LocalPlayer.ActorNumber playertag;

    

    public string NameOfPlayer;
    public string SaveName;

    public TextMeshProUGUI InputText;
    public TextMeshProUGUI LoadedName;
    public GameObject NameTaken;


    // Start is called before the first frame update
    void Start()
    {
        NameTaken.SetActive(false);
        //UnityEngine.Debug.Log(playertag);

    }

    // Update is called once per frame
    void Update()
    {
        NameOfPlayer = PlayerPrefs.GetString("name" , "none");
        LoadedName.text = NameOfPlayer;
       
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SetName();
        }
    }


    public void SetName()
    {
        SaveName = InputText.text;
        PlayerPrefs.SetString("name" , SaveName);
        
        if (playernames.PlayerNamesList.Contains(SaveName))
        {
            NameTaken.SetActive(true);
        }
        else
        {
            playernames.PlayerNamesList.Add(SaveName);
            PhotonNetwork.LoadLevel("Loading");
        }
    }
}
