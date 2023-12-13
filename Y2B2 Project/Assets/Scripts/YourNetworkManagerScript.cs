using Unity.Netcode;
using UnityEngine;
using System.Collections.Generic;

public class YourNetworkManagerScript : NetworkManager
{
    public GameObject playerPrefab;
    private List<GameObject> spawnPrefabs = new List<GameObject>();
    public Canvas canvas; // Add this line to define the Canvas

    void Start()
    {
        // Add listeners for server and client started events
        OnServerStarted += OnServerStartedHandler;
        OnClientStarted += OnClientStartedHandler;
    }

    private void OnServerStartedHandler()
    {
        Debug.Log("Server started. Registering player prefab for spawning.");
        RegisterPrefab(playerPrefab); // Register your player prefab for spawning
        Instantiate(playerPrefab, canvas.transform);
    }

    private void OnClientStartedHandler()
    {
        Debug.Log("Client started. Registering player prefab for spawning.");
        RegisterPrefab(playerPrefab); // Register your player prefab for spawning
        Instantiate(playerPrefab, canvas.transform);
    }

    private void OnStartHostHandler()
    {
        Debug.Log("Host started. Registering player prefab for spawning.");
        RegisterPrefab(playerPrefab); // Register your player prefab for spawning
    }

    private void RegisterPrefab(GameObject prefab)
    {
        spawnPrefabs.Add(prefab); // Add the prefab to the list
        Debug.Log($"Prefab {prefab.name} registered for spawning.");
    }
}
