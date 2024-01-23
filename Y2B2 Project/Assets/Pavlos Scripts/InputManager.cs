using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    public TMP_InputField inputField;

    public void SubmitResponse()
    {
        if (!string.IsNullOrEmpty(inputField.text))
        {
           
            inputField.text = ""; // Clear the field after submission
        }
    }
}
