using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class CountdownController : MonoBehaviour
{
    public int countdownTime;
    public TextMeshProUGUI countdownDisplay;
    public string nextSceneName;

    private void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            yield return new WaitForSeconds(1f);
            countdownTime--;
            countdownDisplay.text = countdownTime.ToString();
        }
        countdownDisplay.text = "GO";

        // When countdown reaches zero, load the next scene
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(nextSceneName); // Replace "VotingSceneName" with your actual scene name
        }
    }
}