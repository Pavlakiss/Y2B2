using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonColor : MonoBehaviour
{
    public void ChangeColor()
    {
        gameObject.GetComponent<Image>().color = Color.grey;
    }
}
