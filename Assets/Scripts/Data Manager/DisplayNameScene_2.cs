using UnityEngine;
using UnityEngine.UI;

public class DisplayNameScene_2 : MonoBehaviour
{
    public Text playerNameText;

    private void Start()
    {
        // Retrieve the name from PlayerPrefs and display it
        string playerName = PlayerPrefs.GetString("PlayerName");
        playerNameText.text = playerName+","; // Update the text component with the retrieved name
    }
}
