using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Photon.Pun;

public class DisplayResponses : MonoBehaviour
{
    public List<TMP_Text> optionTexts; // Assign these in the inspector
    void OnEnable()
    {
        UpdateDisplayWithResponses();
    }
    void UpdateDisplayWithResponses()
    {
        object responses;
        if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue("responses", out responses))
        {
            string[] responsesArray = responses as string[];
            if (responsesArray != null && responsesArray.Length > 0)
            {
                List<string> playerResponses = new List<string>(responsesArray);
                UpdateVotingOptions(playerResponses);
            }
            else
            {
                Debug.LogWarning("No responses found in room properties or array is empty.");
            }
        }
        else
        {
            Debug.LogWarning("Custom property 'responses' not found in room properties.");
        }
    }

    public void UpdateVotingOptions(List<string> newResponses)
    {
        Debug.Log($"Updating responses: {string.Join(", ", newResponses)}");

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
