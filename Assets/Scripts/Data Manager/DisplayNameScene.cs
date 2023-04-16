using UnityEngine;
using UnityEngine.UI;

public class DisplayNameScene : MonoBehaviour
{
    public Text playerNameText;

    private void Start()
    {
        // Retrieve the name from PlayerPrefs and display it
        string playerName = PlayerPrefs.GetString("PlayerName");
        playerNameText.text = "Hi " + playerName+","; // Update the text component with the retrieved name
    }
}
