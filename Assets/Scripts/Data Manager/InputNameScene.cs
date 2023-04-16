using UnityEngine;
using UnityEngine.UI;

public class InputNameScene : MonoBehaviour
{
    public InputField nameInputField;

    // Called when the "Submit" button is clicked
    public void OnSubmitButtonClicked()
    {
        string playerName = nameInputField.text; // Get the name input from the input field
        PlayerPrefs.SetString("PlayerName", playerName); // Save the name input to PlayerPrefs
    }
}
