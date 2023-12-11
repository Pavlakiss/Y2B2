using UnityEngine;
using MLAPI;
using MLAPI.Messaging;

public class PlayerSpawner : NetworkBehaviour
{
    public GameObject playerPrefab;

    void Start()
    {
        SpawnPlayerServerRpc(OwnerClientId);
    }

    [ServerRpc]
    void SpawnPlayerServerRpc(ulong clientId)
    {
        GameObject player = Instantiate(playerPrefab);
        NetworkObject playerNetworkObject = player.GetComponent<NetworkObject>();
        playerNetworkObject.SpawnAsPlayerObject(clientId);
    }
}
