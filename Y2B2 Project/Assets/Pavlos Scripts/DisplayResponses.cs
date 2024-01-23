using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Photon.Pun;

public class DisplayResponses : MonoBehaviour
{
    public List<TMP_Text> optionTexts; // Assign these in the inspector

    void Start()
    {
        List<string> responses = new List<string>();
        // Assuming you have saved each player's response with their nickname as the key
        foreach (var player in PhotonNetwork.PlayerList)
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue(player.NickName, out object response))
            {
                responses.Add(response as string);
            }
        }
        UpdateVotingOptions(responses);
    }

    public void UpdateVotingOptions(List<string> newResponses)
    {
        for (int i = 0; i < optionTexts.Count; i++)
        {
            if (i < newResponses.Count)
            {
                optionTexts[i].text = newResponses[i];
            }
            else
            {
                optionTexts[i].text = ""; // Clear the text if there are not enough new responses
            }
        }
    }
}
