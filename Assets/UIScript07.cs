using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript07 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] questionGroupArr;
    public QAClass07[] qaArr;
    public GameObject AnswerPannel;
    void Start()
    {
        qaArr=new QAClass07[questionGroupArr.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubmitAnswer()
    {
        for (int i=0;i<qaArr.Length;i++)
        {
            qaArr[i]=ReadQuestionAndAnswer(questionGroupArr[i]);
        }
    }

    QAClass07 ReadQuestionAndAnswer(GameObject questionGroup)
    {
        QAClass07 result=new QAClass07();
        GameObject q=questionGroup.transform.Find("Question").gameObject;
        GameObject a=questionGroup.transform.Find("Answer").gameObject;

        result.Question=q.GetComponent<Text>().text;

        if (a.GetComponent<ToggleGroup>()!=null)
        {
            for(int i=0;i<a.transform.childCount;i++)
            {
                if (a.transform.GetChild(i).GetComponent<Toggle>().isOn)
                {
                    result.Answer=a.transform.GetComponent<Text>().text;
                    //a.transform.GetChild(i).Find("label").GetComponent<RawImage>().texture;
                    break;
                }
            }
        }
        return result;
    }
}
[System.Serializable]
public class QAClass07{
    public string Question="";
    public string Answer="";

}