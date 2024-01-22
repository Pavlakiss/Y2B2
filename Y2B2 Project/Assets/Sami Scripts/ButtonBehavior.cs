using Photon.Pun;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public VoteMechanic votemechanic;
    public string ButtonOption;
    public string creatorName;
    public string VotingPlayer;

    public void OnButtonPress()
    {
        // First, check if the VoteMechanic script is assigned
        if (votemechanic == null)
        {
            Debug.LogError("VoteMechanic is not assigned. Please assign it in the inspector.");
            return;
        }

        // Check if we're currently in the VotingPhase
        if (!votemechanic.VotingPhase)
        {
            Debug.LogWarning("It's not the voting phase right now.");
            return;
        }

        // If everything is in order, send the vote
        Debug.Log("Vote button pressed for option: " + ButtonOption);
        PhotonView photonView = votemechanic.GetComponent<PhotonView>();
        if (photonView != null)
        {
            photonView.RPC("ReceiveVote", RpcTarget.All, ButtonOption);
        }
        else
        {
            Debug.LogError("Could not find PhotonView component on VoteMechanic.");
        }
    }
}
