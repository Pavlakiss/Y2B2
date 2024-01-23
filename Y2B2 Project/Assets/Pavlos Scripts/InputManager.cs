using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    public static List<string> playerResponses = new List<string>(); // This list will store the responses
    public TMP_InputField inputField;

    public void SubmitResponse()
    {
        if (!string.IsNullOrEmpty(inputField.text))
        {
            playerResponses.Add(inputField.text); // Add the input text to the responses list
            inputField.text = ""; // Clear the input field
        }
    }
}
