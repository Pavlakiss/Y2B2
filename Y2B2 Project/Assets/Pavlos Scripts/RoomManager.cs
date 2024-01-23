using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput; // Input field for creating a room
    public TMP_InputField joinInput; // Input field for joining a room
    public TMP_Text roomInfoText; // Text element to display room info
    public TMP_Text playerListText; // Text element to display the list of players in the room
    public Button joinButton; // Button to join a room
    public Button createButton; // Button to create a room

    void Start()
    {
        // Initialize UI
        roomInfoText.text = "";
        playerListText.text = "";
    }

    public void CreateRoom()
    {
        string roomName = createInput.text;
        Debug.Log("Trying to create room with name: " + roomName);
        if (!string.IsNullOrEmpty(roomName))
        {
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = 2; // You can set the max players for the room
            PhotonNetwork.CreateRoom(roomName, options);
        }
        else
        {
            Debug.LogError("Room name is empty or null."); // Add this line
        }
    }

    public void JoinRoom()
    {
        string roomName = joinInput.text;
        if (!string.IsNullOrEmpty(roomName))
        {
            PhotonNetwork.JoinRoom(roomName);
        }
    }

    public override void OnJoinedRoom()
    {
        roomInfoText.text = "Joined Room: " + PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();
        PhotonNetwork.LoadLevel("Game"); // Load the game scene
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        roomInfoText.text = "Room creation failed: " + message;
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        roomInfoText.text = "Room joining failed: " + message;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        roomInfoText.text = newPlayer.NickName + " joined the room.";
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        roomInfoText.text = otherPlayer.NickName + " left the room.";
        UpdatePlayerList();
    }

    void UpdatePlayerList()
    {
        playerListText.text = "Players in Room:\n";
        foreach (var player in PhotonNetwork.PlayerList)
        {
            playerListText.text += player.NickName + "\n";
        }
    }
}