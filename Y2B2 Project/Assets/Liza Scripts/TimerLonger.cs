using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class TimerLonger : MonoBehaviour
{
    public float totalTimeInSeconds = 120;  // Set the total time in seconds
    private float elapsedTime;
    private bool isTimerRunning = true;

    public TextMeshProUGUI countdownTimeText;

    public string nextSceneName;

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;

            // Calculate remaining time
            float remainingTime = totalTimeInSeconds - elapsedTime;

            // Format the time as minutes and seconds
            string timerText = string.Format("{0:00}:{1:00}", Mathf.Floor(remainingTime / 60), Mathf.Floor(remainingTime % 60));

            // Display the formatted time
            countdownTimeText.text = timerText;

            // Check if the time has reached zero
            if (remainingTime <= 0)
            {
                isTimerRunning = false;
                Debug.Log("Timer has reached zero!");
                // You can perform any actions you want when the timer reaches zero here

                if (PhotonNetwork.IsMasterClient)
                {
                    PhotonNetwork.LoadLevel(nextSceneName);
                }
            }
        }
    }
}
