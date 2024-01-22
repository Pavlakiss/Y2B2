using UnityEngine;
using Photon.Pun;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;

    public void LoadScene()
    {
        PhotonNetwork.LoadLevel(sceneToLoad);
    }
}
