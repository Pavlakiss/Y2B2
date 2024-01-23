using UnityEngine;
using TMPro;
using System.Collections.Generic;


public class DisplayResponses : MonoBehaviour
{
    public List<TMP_Text> optionTexts; // Assign these in the inspector

    void Start()
    {
        UpdateVotingOptions(InputManager.playerResponses);
    }

    public void UpdateVotingOptions(List<string> newResponses)
    {
        for (int i = 0; i < optionTexts.Count; i++)
        {
            if (i < newResponses.Count)
            {
                optionTexts[i].text = newResponses[i]; // Assign each response to a separate TMP_Text
            }
            else
            {
                optionTexts[i].text = ""; // Clear the text if there are not enough new responses
            }
        }
    }

}
