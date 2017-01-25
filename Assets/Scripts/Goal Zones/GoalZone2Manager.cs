using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone2Manager : MonoBehaviour {

	public GameObject ball;

	void OnTriggerEnter(Collider collider) {
		if(collider.gameObject == ball){
			SceneManager.scoreGoalForPlayer1();
		}
	}
}