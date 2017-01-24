using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone2Manager : MonoBehaviour {

	public GameObject ball;
	SceneManager sceneManager = new SceneManager ();

	void OnTriggerEnter(Collider collider) {
		if(collider.gameObject == ball){
			sceneManager.scoreGoalForPlayer1();
		}
	}
}