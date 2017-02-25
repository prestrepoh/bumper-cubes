using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone1ManagerMP : MonoBehaviour {

	public GameObject ball;
	public GameObject sceneManager;

	private SceneManagerMP sceneManagerMPScript;

	void Start(){
		sceneManagerMPScript = sceneManager.GetComponent<SceneManagerMP> ();
	}

	void OnTriggerEnter(Collider collider) {
		if(collider.gameObject == ball){
			sceneManagerMPScript.scoreGoalForPlayer2 ();
		}
	}
}
