using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class VoteMechanic : MonoBehaviourPunCallbacks
{
    public int totalPlayers = 5;
    private Dictionary<string, int> votes = new Dictionary<string, int>(); // To store the votes for each option
    private HashSet<int> playersWhoVoted = new HashSet<int>(); // To store the IDs of players who have already voted
    public bool PlayerPhase;
    public bool VotingPhase;
    public bool ReadyPhase;
    public bool ResultPhase;

    void Start()
    {
        VotingPhase = true;
    }

    // Method to change player's phase to ready
    public void ChangeToReadyPhase()
    {
        VotingPhase = false;
        ReadyPhase = true;
        Debug.Log("ReadyPhase");
        CheckIfAllVotesReceived();
    }

    // Method to change to result phase
    public void ChangeToResultPhase()
    {
        ResultPhase = true;
        ReadyPhase = false;
        Debug.Log("ResultPhase");
        // Here you can handle what happens when the result phase is reached
    }

    // Method to check if all votes are received
    private void CheckIfAllVotesReceived()
    {
        if (votes.Count == totalPlayers)
        {
            ChangeToResultPhase();
        }
    }

    // RPC to receive votes
    [PunRPC]
    public void ReceiveVote(string option, PhotonMessageInfo info)
    {
        int voterId = info.Sender.ActorNumber;

        // Check if the player has already voted
        if (playersWhoVoted.Contains(voterId))
        {
            Debug.Log($"Player {voterId} has already voted.");
            return;
        }

            if (!votes.ContainsKey(option))
        {
            votes[option] = 0;
        }
        votes[option]++;


        // Add the player's ID to the set of players who have voted
        playersWhoVoted.Add(voterId);
        Debug.Log($"Vote received for option {option}. Total votes for this option: {votes[option]}");
        CheckIfAllVotesReceived();
    }
}
