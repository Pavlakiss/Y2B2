using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement; // Add this to use SceneManager

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public string startScreenSceneName = "StartScreen"; // Name of the start screen scene

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
        SceneManager.LoadScene(startScreenSceneName); // Load the start screen scene
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from Photon Server. Cause: " + cause.ToString());
        // Handle reconnection or inform the user
    }
}
