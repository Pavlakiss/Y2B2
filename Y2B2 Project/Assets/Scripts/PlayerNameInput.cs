using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerNameInput : MonoBehaviour
{
    public string NameOfPlayer;
    public string SaveName;

    public TextMeshProUGUI InputText;
    public TextMeshProUGUI LoadedName;

    public static List<string> PlayerNamesList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NameOfPlayer = PlayerPrefs.GetString("name" , "none");
        LoadedName.text = NameOfPlayer;
    }


    public void SetName()
    {
        SaveName = InputText.text;
        PlayerPrefs.SetString("name" , SaveName);
        PlayerNamesList.Add(SaveName);
        UnityEngine.Debug.Log(PlayerNamesList.Count);
    }
}
