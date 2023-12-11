using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkBehaviourCore;

public class PlayerSpawner : NetworkBehaviour
{
    public GameObject playerPrefab;

    public void Start()
    {
        SpawnPlayerServerRpc(NetworkManager.Singleton.LocalClientId);
    }

    [ServerRpc]
    void SpawnPlayerServerRpc(ulong clientId)
    {
        GameObject player = Instantiate(playerPrefab);

        // Ensure that the spawned player has a NetworkObject component
        NetworkObject playerNetworkObject = player.GetComponent<NetworkObject>();

        // Check if the playerNetworkObject is not null
        if (playerNetworkObject != null)
        {
            // Set the owner client ID for the spawned player
            playerNetworkObject.OwnerClientId = clientId;

            // Spawn the player object
            playerNetworkObject.Spawn();
        }
    }
}
