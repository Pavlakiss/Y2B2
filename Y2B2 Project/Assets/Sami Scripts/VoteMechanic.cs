using UnityEngine;
using UnityEngine.UI;

public class VoteMechanic : MonoBehaviour
{
    public int totalPlayers = 5;
    public int votesReceived = 0;
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
        if (votesReceived == totalPlayers)
        {
            ChangeToResultPhase();
        }
    }

     public void ChangeToResultPhase()
    {
        ResultPhase = true;
        ReadyPhase = false;
        Debug.Log("ResultPhase");
    }

    public void VotesRecived()
    {


    }

}



