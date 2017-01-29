using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStartManager : MonoBehaviour {
	
	public GameObject player1;
	public GameObject player2;
	public GameObject ball;
	public GameObject timer;

	public float minimumBallStartingForce;
	public float maximumBallStartingForce;

	private Vector3 player1StartingPosition;
	private Vector3 player2StartingPosition;
	private Vector3 ballStartingPosition;

	private Quaternion player1StartingRotation;
	private Quaternion player2StartingRotation;

	private TimerManager timerManagerScript;
	private ScoreManager scoreManagerScript;

	void Start(){
		timerManagerScript = timer.GetComponent<TimerManager> ();
		scoreManagerScript = gameObject.GetComponentInParent<ScoreManager>();

		player1StartingPosition = player1.transform.position;
		player2StartingPosition = player2.transform.position;
		ballStartingPosition = ball.transform.position;

		player1StartingRotation = player1.transform.rotation;
		player2StartingRotation = player2.transform.rotation;

		setBallToInitialState ();
	}

	public void restartScene(){
		player1.transform.position = player1StartingPosition;
		player2.transform.position = player2StartingPosition;

		setBallToInitialState ();

		player1.transform.rotation = player1StartingRotation;
		player2.transform.rotation = player2StartingRotation;

		timerManagerScript.restartTimer ();
		scoreManagerScript.restartScoreTexts ();
	}

	private void setBallToInitialState(){
		ball.transform.position = ballStartingPosition;
		Vector3 initialForce = new Vector3(0,0,Random.Range(minimumBallStartingForce,maximumBallStartingForce));
		ball.GetComponent<Rigidbody> ().AddForce(initialForce);
	}
		
}
