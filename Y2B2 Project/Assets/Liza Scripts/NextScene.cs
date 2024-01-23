using UnityEngine;
using Photon.Pun;
using TMPro;

public class NextScene : MonoBehaviour
{
    public string sceneToLoad;

    void Start()
    {
        for (int i = 0; i < InputManager.playerResponses.Count; i++)
        {
            GameObject.Find("Option" + (i + 1).ToString()).GetComponent<TMP_Text>().text = InputManager.playerResponses[i];
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PhotonNetwork.LoadLevel(sceneToLoad);
        }
    }
}