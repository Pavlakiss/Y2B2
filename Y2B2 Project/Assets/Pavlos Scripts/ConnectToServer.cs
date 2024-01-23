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

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon Master Server!");
        // Optionally load a scene or enable UI for room creation/joining
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from Photon Server. Cause: " + cause.ToString());
        // Handle reconnection or inform the user
    }
}
