using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class AnimationTutorialController : MonoBehaviour
{
    public float totalTimeInSeconds;  // Set the total time in seconds
    public float elapsedTime;
    private bool isTimerRunning = true;

    public TextMeshProUGUI countdownTimeText;

    public string nextSceneName;

    public GameObject[] gameObjects;
    public Animator[] animators;

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;

            // Calculate remaining time
            float remainingTime = totalTimeInSeconds - elapsedTime;

            // Display the formatted time
            countdownTimeText.text = remainingTime.ToString("F0");

            // Check if the time has reached zero
            if (remainingTime <= 0)
            {
                isTimerRunning = false;
                Debug.Log("Timer has reached zero!");
                // You can perform any actions you want when the timer reaches zero here

                SceneManager.LoadScene(nextSceneName);
            }
        }

        if (elapsedTime >=9)
        {
                gameObjects[0].SetActive(true);
                animators[0].SetTrigger("Play");
        }
    }
}
