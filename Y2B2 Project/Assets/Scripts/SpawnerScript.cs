using Unity.Netcode;
using UnityEngine;

public class SpawnerScript : NetworkBehaviour
{
    public GameObject playerPrefab; // Assign this in the Inspector

    void Start()
    {
        if (IsServer)
        {
            SpawnPlayer();
        }
    }

    void SpawnPlayer()
    {
        var player = Instantiate(playerPrefab, transform.position, Quaternion.identity);

        // Attach the NetworkObject component to the spawned player GameObject
        NetworkObject networkObject = player.GetComponent<NetworkObject>();

        if (networkObject != null)
        {
            networkObject.Spawn(destroyWithScene: true);
        }
        else
        {
            Debug.LogError("NetworkObject component not found on the spawned player.");
        }
    }
}
