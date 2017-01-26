using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {

	public float timeLeft;
	public GameObject timerText;
	public GameObject sceneManager;

	private SceneManager sceneManagerScript;
	float minutesLeft;
	float secondsLeft;

	void Start(){
		sceneManagerScript = sceneManager.GetComponent<SceneManager> ();
	}

	void Update () {
		
		timeLeft -= Time.deltaTime; 
		minutesLeft = Mathf.Floor (timeLeft / 60);
		secondsLeft = Mathf.Floor (timeLeft % 60);

		if (timeLeft <= 0) {
			timeLeft = 0;
			minutesLeft = 0;
			secondsLeft = 0;
			sceneManagerScript.timeUp ();
		} 

		timerText.GetComponent<Text>().text = minutesLeft.ToString("00") + ":" + secondsLeft.ToString("00");
	}
}
