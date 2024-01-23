using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

public class InputManager : MonoBehaviour
{
    public static List<string> playerResponses = new List<string>();
    public TMP_InputField inputField;
    private PhotonView photonView;

    void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    public void SubmitResponse()
    {
        if (!string.IsNullOrEmpty(inputField.text))
        {
            playerResponses.Add(inputField.text);
            inputField.text = ""; // Clear the field after submission
            // UpdateResponsesUI(); // Call this if you have a method to update the UI
            photonView.RPC("SubmitResponse", RpcTarget.Others, inputField.text);
        }
    }

    [PunRPC]
    public void SubmitResponse(string response, PhotonMessageInfo info)
    {
        int playerId = info.Sender.ActorNumber; // Unique identifier for the player

        if (!string.IsNullOrEmpty(response))
        {
            playerResponses.Add(response);
            // UpdateResponsesUI(); // Update the UI to display new responses
        }
    }
}
