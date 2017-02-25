using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarsManager : MonoBehaviour {

	public GameObject ball;
	public GameObject sceneManager;
	public GameObject pillarsZone1;
	public GameObject pillarsZone2;

	private SceneManager sceneManagerScript;

	void Start(){
		sceneManagerScript = sceneManager.GetComponent<SceneManager> ();
	}

	void OnTriggerEnter(Collider collider) {
		if ((this.gameObject.name == "Pillar Left 1" ||
			this.gameObject.name == "Pillar Left 2" ||
			this.gameObject.name == "Pillar Right 1" ||
			this.gameObject.name == "Pillar Right 2") &&
			collider.gameObject == ball) {
			sceneManagerScript.missGoalSound ();
		}
	}
}
