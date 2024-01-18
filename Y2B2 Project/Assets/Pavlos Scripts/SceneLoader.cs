using UnityEngine;
using Photon.Pun;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene()
    {
        PhotonNetwork.LoadLevel("Timer");
    }
}
