using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone1Manager : MonoBehaviour {

	public GameObject ball;
	SceneManager sceneManager = new SceneManager ();

	void OnTriggerEnter(Collider collider) {
		if(collider.gameObject == ball){
			sceneManager.scoreGoalForPlayer2 ();
		}
	}
}