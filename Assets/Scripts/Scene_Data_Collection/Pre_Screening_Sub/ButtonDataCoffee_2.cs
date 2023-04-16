using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class ButtonDataCoffee_2 : MonoBehaviour
{
    public Button firstButton;
    public Button secondButton;
    public Button thirdButton;
    public Button submitButton;

    private string selectedOption = ""; // Stores the selected option

    private void Start()
    {
        submitButton.onClick.AddListener(SubmitForm);
        firstButton.onClick.AddListener(() => OnOptionButtonClicked("1-5"));
        secondButton.onClick.AddListener(() => OnOptionButtonClicked("6-10"));
        thirdButton.onClick.AddListener(() => OnOptionButtonClicked("11-20"));
  
    }

    private void SubmitForm()
    {
        // Create the form data
        WWWForm form = new WWWForm();
        form.AddField("entry.1784168504", selectedOption); // Option field ID

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
