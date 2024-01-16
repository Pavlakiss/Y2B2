using Photon.Pun;
using UnityEngine;
using ExitGames.Client.Photon;
using System.Collections.Generic;

public class PlayerNames : MonoBehaviourPunCallbacks
{
    public static PlayerNames Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public bool CheckIfNameIsAvailable(string nameToCheck)
    {
        foreach (var player in PhotonNetwork.PlayerList)
        {
            if (player.CustomProperties.TryGetValue("playerName", out object playerName))
            {
                if (playerName.ToString() == nameToCheck)
                {
                    return false; // Name is already taken
                }
            }
        }
        return true; // Name is available
    }

    public void SavePlayerName(string playerName)
    {
        PhotonNetwork.LocalPlayer.NickName = playerName; // Set the local player's nickname

        Hashtable playerNameProp = new Hashtable
        {
            { "playerName", playerName }
        };
        PhotonNetwork.LocalPlayer.SetCustomProperties(playerNameProp); // Set the custom properties for the player
    }
}
