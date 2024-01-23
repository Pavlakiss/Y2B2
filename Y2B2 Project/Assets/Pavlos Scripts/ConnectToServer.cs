using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
//using ExitGames.Client.Photon;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
void Start()
{
    if (!PhotonNetwork.IsConnected)
    {
        PhotonNetwork.ConnectUsingSettings(); // Connect to Photon servers
        PhotonNetwork.GameVersion = "1.0"; // Set your game version
    }
}


    // This function should handle the event when the connection to the master server fails.
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Failed to connect to Photon Server. Cause: " + cause.ToString());
    }

    // This function is called as soon as you are connected with the master server and ready to join a lobby.
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon Master Server!");
        PhotonNetwork.JoinLobby();
    }

   
    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Photon Lobby!");

        PhotonNetwork.LoadLevel("StartScreen");
    }
}