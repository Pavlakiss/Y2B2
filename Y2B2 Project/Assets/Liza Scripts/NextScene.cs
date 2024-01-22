using UnityEngine;
using Photon.Pun;

public class NextScene : MonoBehaviour
{
    public string sceneToLoad;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PhotonNetwork.LoadLevel(sceneToLoad);
        }
    }
}