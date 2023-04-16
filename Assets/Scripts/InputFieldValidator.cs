using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputFieldValidator : MonoBehaviour
{
    public InputField[] inputFields;

    public void ValidateInputFieldsAndMoveToNextScene(string nextSceneName)
    {
        bool allFieldsFilled = true;
        foreach (InputField inputField in inputFields)
        {
            if (string.IsNullOrEmpty(inputField.text))
            {
                allFieldsFilled = false;
                break;
            }
        }

        if (allFieldsFilled)
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Please fill in all input fields before proceeding.");
        }
    }
}
