using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Info_Script : MonoBehaviour
{

    [SerializeField] InputField feedback1;
    [SerializeField] InputField feedback2;
    [SerializeField] InputField feedback3;
    [SerializeField] InputField feedback4;

    string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScy_1xX00yR2nvE00TFFY-rRH3p1IscJHUbj4js6TepDaqdQA/formResponse";

    
    public void Send()
    {
        StartCoroutine(Post(feedback1.text,feedback2.text,feedback3.text,feedback4.text));
    }

    IEnumerator Post(string s1,string s2,string s3,string s4)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.2089029228", s1);
        form.AddField("entry.266327886", s2);
        form.AddField("entry.842354736", s3);
        form.AddField("entry.1107229957", s4);
        


        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        
        yield return www.SendWebRequest();

    }


}