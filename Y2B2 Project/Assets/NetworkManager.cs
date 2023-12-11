using UnityEngine;
using MLAPI;

public class NetworkManager : MonoBehaviour
{
    void Start()
    {
        NetworkManager.Singleton.StartHost();
    }
}
