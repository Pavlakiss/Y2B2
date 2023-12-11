using UnityEngine;
using MLAPI;
using MLAPI.Messaging;

public class PlayerMovement : NetworkBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        if (IsLocalPlayer)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            // Send movement to server
            SendMovementServerRpc(transform.position);
        }
    }

    [ServerRpc]
    void SendMovementServerRpc(Vector3 position)
    {
        // Update position on server
        transform.position = position;

        // Send updated position to all clients
        SendMovementClientRpc(position);
    }

    [ClientRpc]
    void SendMovementClientRpc(Vector3 position)
    {
        // Update position on all clients
        transform.position = position;
    }
}
