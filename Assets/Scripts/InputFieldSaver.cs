using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class InputFieldSaver : MonoBehaviour
{
    [SerializeField] private InputField inputField1;
    [SerializeField] private InputField inputField2;
    [SerializeField] private InputField fileNameField;
    [SerializeField] private Button maleButton;
    [SerializeField] private Button femaleButton;
    [SerializeField] private Button transButton;
    [SerializeField] private Button otherButton;

    private string selectedGender = "";

    private void Start()
    {
        maleButton.onClick.AddListener(OnMaleButtonClicked);
        femaleButton.onClick.AddListener(OnFemaleButtonClicked);
        transButton.onClick.AddListener(transButtonClicked);
        otherButton.onClick.AddListener(OnOtherButtonClicked);
    }

    private void OnMaleButtonClicked()
    {
        selectedGender = "Male";
    }

    private void OnFemaleButtonClicked()
    {
        selectedGender = "Female";
    }

    private void transButtonClicked()
    {
        selectedGender = "Transgender";
    }

    private void OnOtherButtonClicked()
    {
        selectedGender = "Other";
    }

    public void SaveInputFieldsToFile()
    {
        if (string.IsNullOrEmpty(inputField1.text) || string.IsNullOrEmpty(inputField2.text))
        {
            Debug.LogWarning("Input fields are empty, cannot save.");
            return;
        }

        string fileName = fileNameField.text;
        if (string.IsNullOrEmpty(fileName))
        {
            Debug.LogWarning("File name is empty, cannot save.");
            return;
        }

        string filePath = Application.dataPath + "/" + fileName+".text";

        try
        {
            StreamWriter writer = new StreamWriter(filePath, false);

            writer.WriteLine(inputField1.text);
            writer.WriteLine(inputField2.text);
            writer.WriteLine(selectedGender);

            writer.Close();

            Debug.Log("Input fields saved to file: " + filePath);
        }
        catch (IOException ex)
        {
            Debug.LogError("Error saving input fields to file: " + ex.Message);
        }
    }
}
