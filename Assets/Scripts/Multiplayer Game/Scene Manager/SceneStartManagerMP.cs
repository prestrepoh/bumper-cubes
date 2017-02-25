using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SceneStartManagerMP : MonoBehaviour {
	
	public GameObject ball;
	public float minimumBallStartingForce;
	public float maximumBallStartingForce;

	private Vector3 ballStartingPosition;

	void Start(){
		ballStartingPosition = ball.transform.position;
	}

	public void setBallToInitialState(){
		ball.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		ball.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		ball.transform.position = ballStartingPosition;
		Vector3 initialForce = new Vector3(0,0,Random.Range(minimumBallStartingForce,maximumBallStartingForce));
		ball.GetComponent<Rigidbody> ().AddForce(initialForce);
	}
}
