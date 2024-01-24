using Photon.Pun;
using UnityEngine;
using System.Collections.Generic;

public class VoteMechanic : MonoBehaviourPunCallbacks
{
    public int totalPlayers = 2;
    private Dictionary<string, int> votes = new Dictionary<string, int>();
    private HashSet<int> playersWhoVoted = new HashSet<int>();
    public bool VotingPhase;
    public bool ReadyPhase;
    public bool ResultPhase;

    void Start()
    {
        VotingPhase = true;
    }

    public void ChangeToReadyPhase()
    {
        VotingPhase = false;
        ReadyPhase = true;
        Debug.Log("ReadyPhase");
        CheckIfAllVotesReceived();
    }

    public void ChangeToResultPhase()
    {
        ResultPhase = true;
        ReadyPhase = false;
        Debug.Log("ResultPhase");
    }

    private void CheckIfAllVotesReceived()
    {
        if (votes.Count == totalPlayers)
        {
            ChangeToResultPhase();
        }
    }

    [PunRPC]
    public void ReceiveVote(string option, PhotonMessageInfo info)
    {
        if (playersWhoVoted.Contains(info.Sender.ActorNumber))
        {
            Debug.LogWarning("This player has already voted.");
            return;
        }

        if (!votes.ContainsKey(option))
        {
            votes[option] = 0;
        }
        votes[option]++;
        playersWhoVoted.Add(info.Sender.ActorNumber);

        Debug.Log($"Vote received for option {option}. Total votes for this option: {votes[option]}");

        if (playersWhoVoted.Count >= totalPlayers)
        {
            ChangeToReadyPhase();
        }
    }
}
