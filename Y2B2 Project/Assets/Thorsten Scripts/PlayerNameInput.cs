using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;
public class PlayerNameInput : MonoBehaviour
{
    public TextMeshProUGUI InputText;
    public TextMeshProUGUI LoadedName;
    public GameObject NameTaken;
    private string NameOfPlayer;
    private string SaveName;

    void Start()
    {
        NameTaken.SetActive(false); // Load previously saved name, if any
        LoadedName.text = PlayerPrefs.GetString("name", "");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TrySetName();
        }
    }

    public void TrySetName()
    {
        SaveName = InputText.text;

        // Check if the name is available using the PlayerNames singleton
        if (PlayerNames.Instance.CheckIfNameIsAvailable(SaveName))
        {
            PlayerPrefs.SetString("name", SaveName); // Save the name locally
            PlayerNames.Instance.SavePlayerName(SaveName); // Save the name to Photon
            GameObject.Find("Button").GetComponent<Image>().color = Color.grey;

            PhotonNetwork.LoadLevel("Lobby"); // Load the next scene
        }
        else
        {
            NameTaken.SetActive(true); // Show the name taken message
        }
    }
}