using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer: MonoBehaviour
{
	public Text timerText;
	private float startTime;

	
	void Start(){
		startTime=Time.time;
	}

	void Update(){
		float t=Time.time-startTime;
		string minutes=((int) t/60).ToString();
		string seconds =(t%60).ToString("f2");

		timerText.text="Timer: "+minutes+":"+seconds;

	}
}
