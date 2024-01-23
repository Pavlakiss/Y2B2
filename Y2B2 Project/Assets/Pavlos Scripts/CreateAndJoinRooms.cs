using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    public TMP_Text roomInfoText; 
    public TMP_Text playerListText;

    public void CreateRoom()
    {
        string roomName = createInput.text;
        if (!string.IsNullOrEmpty(roomName))
        {
            RoomOptions options = new RoomOptions
            {
                MaxPlayers = 2, // Set the max players for the room
                IsOpen = true,  // The room is open to join
                IsVisible = true // The room is visible in the lobby
            };
            PhotonNetwork.CreateRoom(roomName, options);
        }
        else
        {
            Debug.LogError("Room name is empty or null.");
        }
    }

    public void JoinRoom()
    {
        if (!string.IsNullOrEmpty(joinInput.text))
        {
            PhotonNetwork.JoinRoom(joinInput.text);
        }
    }


    public override void OnJoinedRoom()
    {
        roomInfoText.text = "Joined Room: " + PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();

        // Check room properties
        Debug.Log("Room isOpen: " + PhotonNetwork.CurrentRoom.IsOpen);
        Debug.Log("Room isVisible: " + PhotonNetwork.CurrentRoom.IsVisible);
        Debug.Log("Players in room: " + PhotonNetwork.CurrentRoom.PlayerCount + "/" + PhotonNetwork.CurrentRoom.MaxPlayers);
        PhotonNetwork.LoadLevel("Game_Ai");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Room creation failed: " + message);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Room joining failed: " + message);
        // Handle the failed join attempt (e.g., show a message to the player)
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo room in roomList)
        {
            Debug.Log("Room: " + room.Name + " isOpen: " + room.IsOpen + " isVisible: " + room.IsVisible);
        }
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
