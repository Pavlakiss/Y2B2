using UnityEngine;
using UnityEngine.UI;

public class VotingButton : MonoBehaviour
{
    public string creatorName;  // Set this in the Unity Editor for each option
    public Text playerNameText;  // Reference to the UI Text displaying player name
    public int totalPlayers = 5; 
    private int votesReceived = 0;
    public string selectedOption;  // To keep track of the selected option
    private GamePhase currentPhase;
    public bool PlayerPhase;
    public bool VotingPhase;
    public bool ReadyPhase;
    public bool ResultPhase;

    enum GamePhase
    {
        PlayerPhase,
        VotingPhase,
        ReadyPhase,
        ResultPhase
    }

    // Call this method when the button is pressed
    public void ButtonFunction()
    {
            if (PlayerPhase = VotingPhase)

            {
                Debug.Log("Button got clicked");
                string playerName = playerNameText.text;  // Get player name from UI Text

                if (playerName == creatorName)
                {
                    return;
                }
                else
                {
                    // Change player's phase to ready
                    ChangeToReadyPhase();
                    Debug.Log("Ready Phase");

                    // Keep track of the selected option and player
                    selectedOption = transform.name; 
                    // Assuming the button's name corresponds to the option
                    Debug.Log($"{playerName} voted for {selectedOption}.");
                }
        }
    }

    // Method to change player's phase to ready
    void ChangeToReadyPhase()
    {
        if (votesReceived >= totalPlayers)
        {
            ChangeToResultPhase();
        }
    }
    void ChangeToResultPhase()
    {
        Debug.Log("ResultPhase");
    }
}



