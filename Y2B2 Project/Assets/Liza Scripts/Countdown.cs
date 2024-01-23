using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public int countdownTime;
    public TextMeshProUGUI countdown;
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
            countdown.text = countdownTime.ToString();
        }
        countdown.text = "GO";

        // When countdown reaches zero, load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
