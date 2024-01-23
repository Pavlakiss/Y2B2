using Photon.Pun;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class InputManager : MonoBehaviourPun
{
    public TMP_InputField inputField;
    public static List<string> playerResponses = new List<string>();


    [PunRPC]
    void SaveResponse(string playerResponse, PhotonMessageInfo info)
    {
        // Logic to add the response to a shared list or room properties
        // Example using room properties (simplified, actual implementation may vary):
        var responses = PhotonNetwork.CurrentRoom.CustomProperties["responses"] as List<string> ?? new List<string>();
        responses.Add(playerResponse);
        PhotonNetwork.CurrentRoom.CustomProperties["responses"] = responses;
        PhotonNetwork.CurrentRoom.SetCustomProperties(PhotonNetwork.CurrentRoom.CustomProperties);
    }
    public void SubmitResponse()
    {
        playerResponses.Add(inputField.text);
        if (!string.IsNullOrEmpty(inputField.text))
        {
            // Assuming you have a PhotonView attached to this GameObject
            photonView.RPC("SaveResponse", RpcTarget.AllBuffered, inputField.text);
            inputField.text = ""; // Clear the input field after submitting
        }
    }

   
}
