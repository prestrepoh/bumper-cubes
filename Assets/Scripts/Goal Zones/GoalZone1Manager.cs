using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone1Manager : MonoBehaviour {

	public GameObject ball;

	void OnTriggerEnter(Collider collider) {
		if(collider.gameObject == ball){
			SceneManager.scoreGoalForPlayer2 ();
		}
	}
}