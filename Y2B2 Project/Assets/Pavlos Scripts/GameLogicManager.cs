using UnityEngine;
using Photon.Pun;

public class GameLogicManager : MonoBehaviourPunCallbacks
{
    public InputManager inputManager;
    public VoteMechanic voteMechanic;
    public DisplayResponses displayResponses;
    public FakePlayerManager fakePlayerManager;

    void Start()
    {
        StartInputPhase();
    }

    void StartInputPhase()
    {
        TransitionToVotingPhase();
    }

    void TransitionToVotingPhase()
    {
        voteMechanic.VotingPhase = true;
        SimulateFakePlayerVote();
    }

    void SimulateFakePlayerVote()
    {
        string fakeInput = fakePlayerManager.GetRandomInput();
        if (!string.IsNullOrEmpty(fakeInput))
        {
            voteMechanic.ReceiveVote(fakeInput); // Call the overloaded version of ReceiveVote
        }
    }


    public void TransitionToResultPhase()
    {
        voteMechanic.ChangeToResultPhase();
    }
}
