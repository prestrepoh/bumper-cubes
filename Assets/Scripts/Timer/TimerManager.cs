using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {

	public float timeLeft;
	public GameObject timerText;
	public GameObject sceneManager;

	private SceneManager sceneManagerScript;

	void Start(){
		sceneManagerScript = sceneManager.GetComponent<SceneManager> ();
	}

	void Update () {
		
		timeLeft -= Time.deltaTime; 

		if (timeLeft <= 0) {
			timeLeft = 0;
			sceneManagerScript.timeUp ();
		} 

		timerText.GetComponent<Text>().text = timeLeft.ToString();
	}
}
