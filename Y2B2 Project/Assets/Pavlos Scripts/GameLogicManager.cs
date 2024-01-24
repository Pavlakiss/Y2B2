using UnityEngine;
using Photon.Pun;

public class GameLogicManager : MonoBehaviourPunCallbacks
{
    public InputManager inputManager;
    public VoteMechanic voteMechanic;
    public DisplayResponses displayResponses;
    public FakePlayerManager fakePlayerManager;
    public string nextSceneName;

    void Start()
    {
        inputManager = InputManager.Instance;
        StartInputPhase();
    }

    void StartInputPhase()
    {
        TransitionToVotingPhase();
    }

    public static GameLogicManager Instance;

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

    public void HandleAllResponsesCollected()
    {
        // Logic to transition to the voting scene
        TransitionToVotingPhase();
    }
    void TransitionToVotingPhase()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            // Check if all responses are collected
            if (PhotonNetwork.IsMasterClient && AllResponsesCollected()) // Implement this method to check if all responses are ready
            {
                // Transition to the voting scene
                PhotonNetwork.LoadLevel(nextSceneName);
            }
        }
    }
    bool AllResponsesCollected()
    {
        // Fetch the responses from the room properties
        object responsesObj;
        if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue("responses", out responsesObj))
        {
            string[] responses = responsesObj as string[];
            // Check if the number of responses matches the number of players
            return responses != null && responses.Length == PhotonNetwork.CurrentRoom.PlayerCount;
        }
        return false;
    }

        //void SimulateFakePlayerVote()
        //{
        // string fakeInput = fakePlayerManager.GetRandomInput();
        //if (!string.IsNullOrEmpty(fakeInput))
        //{
        // voteMechanic.ReceiveVote(fakeInput); // Call the overloaded version of ReceiveVote
        //}
        //}


    public void TransitionToResultPhase()
    {
      voteMechanic.ChangeToResultPhase();
    }
}
