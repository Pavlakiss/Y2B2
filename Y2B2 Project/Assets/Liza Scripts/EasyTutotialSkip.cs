using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyTutotialSkip : MonoBehaviour
{
    void Update()
    {
        //if key "S" is pressed, skip the tutorial
        if (Input.GetKeyDown(KeyCode.S))
        {
            //load the next scene
            UnityEngine.SceneManagement.SceneManager.LoadScene("Timer");
        }
    }
}
