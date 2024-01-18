using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
//using ExitGames.Client.Photon;

public class ConnectToServer : MonoBehaviourPunCallbacks
{

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

    // This function is automatically called when your initial connection with the server is established and ready.
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable();
        hash.Add("score", 675);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }

    // This function is called when you have successfully joined the lobby.
    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Photon Lobby!");

        PhotonNetwork.LoadLevel("Lobby_NameInput");
    }
}