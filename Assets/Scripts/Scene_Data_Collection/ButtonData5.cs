using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class ButtonData5 : MonoBehaviour
{
    public Button todayButton;
    public Button previousButton;
    public Button pastButton;
    public Button beforeButton;
    public Button noButton;
    public Button submitButton;

    private string selectedOption = ""; // Stores the selected option

    private void Start()
    {
        submitButton.onClick.AddListener(SubmitForm);
        todayButton.onClick.AddListener(() => OnOptionButtonClicked("Today"));
        previousButton.onClick.AddListener(() => OnOptionButtonClicked("Previous day"));
        pastButton.onClick.AddListener(() => OnOptionButtonClicked("Past few day"));
        beforeButton.onClick.AddListener(() => OnOptionButtonClicked("before 1 week"));
        noButton.onClick.AddListener(() => OnOptionButtonClicked("No"));
    }

    private void SubmitForm()
    {
        // Create the form data
        WWWForm form = new WWWForm();
        form.AddField("entry.1532808936", selectedOption); // Option field ID

        // Send the form data to the Google Form URL
        StartCoroutine(SubmitFormCoroutine(form));
    }

    private void OnOptionButtonClicked(string option)
    {
        selectedOption = option;
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
