using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class ButtonDataSaver3 : MonoBehaviour
{
    public InputField departmentInputField;
    public InputField courseInputField;
    public Button fieldOfStudyDesignButton;
    public Button fieldOfStudyNonDesignButton;
    public Button handinessRightButton;
    public Button handinessLeftButton;
    public Button submitButton;

    private string fieldOfStudy;
    private string handiness;

    private void Start()
    {
        fieldOfStudyDesignButton.onClick.AddListener(SelectFieldOfStudyDesign);
        fieldOfStudyNonDesignButton.onClick.AddListener(SelectFieldOfStudyNonDesign);
        handinessRightButton.onClick.AddListener(SelectHandinessRight);
        handinessLeftButton.onClick.AddListener(SelectHandinessLeft);
        submitButton.onClick.AddListener(SubmitForm);
    }

    private void SelectFieldOfStudyDesign()
    {
        fieldOfStudy = "Design";
    }

    private void SelectFieldOfStudyNonDesign()
    {
        fieldOfStudy = "Non Design";
    }

    private void SelectHandinessRight()
    {
        handiness = "Right";
    }

    private void SelectHandinessLeft()
    {
        handiness = "Left";
    }

    private void SubmitForm()
    {
        // Create the form data
        WWWForm form = new WWWForm();
        form.AddField("entry.180760373", departmentInputField.text); // Department field ID
        form.AddField("entry.802952773", courseInputField.text); // Course field ID
        form.AddField("entry.1989712955", fieldOfStudy); // Field of Study field ID
        form.AddField("entry.1239523403", handiness); // Handiness field ID

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
