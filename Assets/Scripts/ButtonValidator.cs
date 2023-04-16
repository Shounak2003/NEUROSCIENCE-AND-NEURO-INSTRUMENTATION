using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonValidator : MonoBehaviour
{
    public Button[] buttons;
    public string nextSceneName;

    private bool atLeastOneButtonClicked = false;

    private void Start()
    {
        // Attach a click event handler to each button
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    private void OnButtonClick(Button button)
    {
        atLeastOneButtonClicked = true;
        // Disable the clicked button
        button.interactable = false;
    }

    public void ValidateButtonsAndMoveToNextScene()
    {
        if (atLeastOneButtonClicked)
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Please click at least one button before proceeding.");
        }
    }
}
