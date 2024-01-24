using Photon.Pun;
using UnityEngine;
using TMPro;
using System.Collections.Generic;


public class InputManager : MonoBehaviourPun
{
    public TMP_InputField inputField;
    public static List<string> playerResponses = new List<string>();
    public static InputManager Instance;
    List<string> responses = new();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    [PunRPC]
    void SaveResponse(string playerResponse, PhotonMessageInfo info)
    {
        // Logic to add the response to a shared list or room properties
        // Example using room properties (simplified, actual implementation may vary):
        string[] responsesArray = PhotonNetwork.CurrentRoom.CustomProperties["responses"] as string[] ?? new string[] { };
        //List<string> responses = new List<string>(responsesArray);

        // Add the new response
        responses.Add(playerResponse);

        // Convert the List<string> back to an array
        responsesArray = responses.ToArray();

        PhotonNetwork.CurrentRoom.CustomProperties["responses"] = responses;
        PhotonNetwork.CurrentRoom.SetCustomProperties(PhotonNetwork.CurrentRoom.CustomProperties);
        CheckAllResponsesCollected();
    }
    void CheckAllResponsesCollected()
    {
        // Check if the number of responses matches the number of players
        if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue("responses", out object responses))
        {
            string[] responsesArray = responses as string[];
            if (responsesArray != null && responsesArray.Length == PhotonNetwork.CurrentRoom.PlayerCount)
            {
                // If all responses are collected, call a method to handle the next steps
                GameLogicManager.Instance.HandleAllResponsesCollected();
            }
        }
    }
    public void SubmitResponse()
    {
        if (!string.IsNullOrEmpty(inputField.text))
        {

   
            // Add the response to the local list (not strictly necessary if you're using room properties)
            playerResponses.Add(inputField.text);

            // Convert the List<string> to an array
            string[] responsesArray = playerResponses.ToArray();

            // Set the updated array as a custom property
            PhotonNetwork.CurrentRoom.SetCustomProperties(new ExitGames.Client.Photon.Hashtable { { "responses", responsesArray } });

            // Clear the input field
            inputField.text = "";

            // Send the response to all clients
            photonView.RPC("SaveResponse", RpcTarget.All, inputField.text);
        }
        Debug.Log($"Submitted Response: {inputField.text}");
        Debug.Log($"All Responses: {string.Join(", ", playerResponses)}");
    }


}
