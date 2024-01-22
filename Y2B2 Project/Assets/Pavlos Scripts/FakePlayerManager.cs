using UnityEngine;
using System.Collections.Generic;

public class FakePlayerManager : MonoBehaviour
{
    public List<string> predeterminedInputs = new List<string>()
    {
        "Fake Input 1",
        "Fake Input 2",
        "Fake Input 3",
        "Fake Input 4",
        "Fake Input 5"
        // Add as many as needed
    };

    public string GetRandomInput()
    {
        if (predeterminedInputs.Count > 0)
        {
            int index = Random.Range(0, predeterminedInputs.Count);
            return predeterminedInputs[index];
        }
        else
        {
            // Optionally handle the case where there are no predefined inputs
            return ""; // or return some default input
        }
    }
}
