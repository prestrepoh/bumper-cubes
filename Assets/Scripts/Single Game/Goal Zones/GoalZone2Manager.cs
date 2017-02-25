using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone2Manager : MonoBehaviour {
	
	public GameObject ball;
	public GameObject sceneManager;

	private SceneManager sceneManagerScript;

	void Start(){
		sceneManagerScript = sceneManager.GetComponent<SceneManager> ();
	}

	void OnTriggerEnter(Collider collider) {
		if(collider.gameObject == ball){
			sceneManagerScript.scoreGoalForPlayer1 ();
		}
	}
}