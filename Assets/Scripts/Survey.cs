
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Survey : MonoBehaviour
{

    [SerializeField] InputField feedback1;
    [SerializeField] InputField feedback2;

    string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScy_1xX00yR2nvE00TFFY-rRH3p1IscJHUbj4js6TepDaqdQA/formResponse";

    
    public void Send()
    {
        StartCoroutine(Post(feedback1.text));
        StartCoroutine(Post(feedback2.text));
    }

    IEnumerator Post(string s1)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.2089029228", s1);      
        UnityWebRequest www = UnityWebRequest.Post(URL, form);       
        yield return www.SendWebRequest();
    }

    IEnumerator Post_2(string s2)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.266327886", s2);
        UnityWebRequest www = UnityWebRequest.Post(URL, form);

        yield return www.SendWebRequest();

    }

}