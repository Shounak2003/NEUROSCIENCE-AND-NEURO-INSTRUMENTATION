using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class ButtonDataSaver_4 : MonoBehaviour
{
    public InputField contact;
    public InputField email;
    public Button submitButton;

    private void Start()
    {
        submitButton.onClick.AddListener(SubmitForm);
    }

    private void SubmitForm()
    {
        // Create the form data
        WWWForm form = new WWWForm();
        //string formData = "Locality: " + localityInputField.text + "\n" +
                         // "City: " + cityInputField.text + "\n" +
                         // "State: " + stateInputField.text + "\n" +
                          //"Place of Birth: " + placeOfBirthInputField.text;
        form.AddField("entry.754502397", contact.text); // conatct field ID
        form.AddField("entry.442779208", email.text); // email field ID

        // Send the form data to the Google Form URL
        StartCoroutine(SubmitFormCoroutine(form));
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
