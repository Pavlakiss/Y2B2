using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    public static List<string> playerResponses = new List<string>(); // Static list to hold responses
    public TMP_InputField inputField;

    public void SubmitResponse()
    {
        if (!string.IsNullOrEmpty(inputField.text))
        {
            // Assuming playerResponses is a static list where you store responses
            // InputManager.playerResponses.Add(inputField.text);

            // Clear the input field
            inputField.text = "";
        }
    }
}

