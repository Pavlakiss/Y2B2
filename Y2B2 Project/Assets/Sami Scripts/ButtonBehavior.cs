using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ButtonBehavior : MonoBehaviour
{ 
    public VoteMechanic votemechanic;
    public string ButtonOption;
    public string creatorName;
    public string VotingPlayer;

    public void OnButtonPress()
    {
        if (votemechanic == null)  // Check if votemechanic is null
        {
            Debug.LogError("VoteMechanic is not assigned, drag the object the script is assigned to into this scripts assigned serialized field.");
            return;
        }

        if (!votemechanic.VotingPhase)
        {
            return;
        }
        else
        {
            Debug.Log("pressed");
            votemechanic.votesReceived++;
            votemechanic.ChangeToReadyPhase();
        }
    }
}
