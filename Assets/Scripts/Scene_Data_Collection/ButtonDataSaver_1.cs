using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class ButtonDataSaver_1 : MonoBehaviour
{
    public InputField nameInputField;
    public InputField ageInputField;
    public Button maleButton;
    public Button femaleButton;
    public Button transgenderButton;
    public Button submitButton;

    private string selectedGender = ""; // Stores the selected gender

    private void Start()
    {
        submitButton.onClick.AddListener(SubmitForm);
        maleButton.onClick.AddListener(() => OnGenderButtonClicked("Male"));
        femaleButton.onClick.AddListener(() => OnGenderButtonClicked("Female"));
        transgenderButton.onClick.AddListener(() => OnGenderButtonClicked("Transgender"));
    }

    private void SubmitForm()
    {
        // Create the form data
        WWWForm form = new WWWForm();
        form.AddField("entry.2089029228", nameInputField.text); // Name field ID
        form.AddField("entry.266327886", ageInputField.text); // Age field ID
        form.AddField("entry.842354736", selectedGender); // Gender field ID
        // Send the form data to the Google Form URL
        StartCoroutine(SubmitFormCoroutine(form));
    }

    private void OnGenderButtonClicked(string gender)
    {
        selectedGender = gender;
    }

    private IEnumerator SubmitFormCoroutine(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post("https://docs.google.com/forms/u/0/d/e/1FAIpQLScy_1xX00yR2nvE00TFFY-rRH3p1IscJHUbj4js6TepDaqdQA/formResponse", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Form data submitted successfully!");
            }
            else
            {
                Debug.LogError("Error submitting form data: " + www.error);
            }
        }
    }
}
