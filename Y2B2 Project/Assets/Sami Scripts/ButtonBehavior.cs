using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    public VoteMechanic votemechanic;
    public string ButtonOption;

    public void OnButtonPress()
    {
        if (votemechanic == null)
        {
            Debug.LogError("VoteMechanic is not assigned. Please assign it in the inspector.");
            return;
        }

        if (!votemechanic.VotingPhase)
        {
            Debug.LogWarning("It's not the voting phase right now.");
            return;
        }

        Debug.Log("Vote button pressed for option: " + ButtonOption);
        // make the button turn grey
        gameObject.GetComponent<Image>().color = Color.grey;

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
