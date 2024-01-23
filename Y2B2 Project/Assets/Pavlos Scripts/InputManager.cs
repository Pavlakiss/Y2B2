using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    public static List<string> playerResponses = new List<string>();
    public TMP_InputField inputField;

    public void SubmitResponse()
    {
        if (!string.IsNullOrEmpty(inputField.text))
        {
            playerResponses.Add(inputField.text);
            inputField.text = ""; // Clear the field after submission
        }
    }
}
