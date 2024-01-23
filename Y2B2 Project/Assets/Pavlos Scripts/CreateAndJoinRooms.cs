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

    public void CreateRoom()
    {
        if (!string.IsNullOrEmpty(createInput.text))
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 4; // Set max players or keep it default
            roomOptions.IsVisible = true; // Ensure the room is visible
            roomOptions.IsOpen = true; // Ensure the room is open to join
            PhotonNetwork.CreateRoom(createInput.text, roomOptions);
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
        PhotonNetwork.LoadLevel("Game_Ai");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Room creation failed: " + message);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Room joining failed: " + message);
    }
}
