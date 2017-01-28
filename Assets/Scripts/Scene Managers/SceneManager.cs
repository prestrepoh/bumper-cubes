using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class SceneManager : MonoBehaviour {

	private int player1Score;
	private int player2Score;
	private bool gameHasEnded;

	private ScoreManager scoreManagerScript; 
	private HUDManager hudManagerScript;

	void Start () {
		player1Score = 0;
		player2Score = 0;
		gameHasEnded = false;

		scoreManagerScript = gameObject.GetComponentInParent<ScoreManager>( );
		hudManagerScript = gameObject.GetComponent<HUDManager> ();
	}

	public void scoreGoalForPlayer1(){
		player1Score++;
		scoreManagerScript.setPlayer1ScoreText (player1Score);
	}

	public void scoreGoalForPlayer2(){
		player2Score++;
		scoreManagerScript.setPlayer2ScoreText (player2Score);
	}

	public void timeUp(){
		
		if (!gameHasEnded) {
			
			gameHasEnded = true;

			if (player1Score > player2Score) {
				player1Wins ();
			} else if (player2Score > player1Score) {
				player2Wins ();
			} else {
				goToGoldenGoal ();
			}
		}

		if(hudManagerScript.allAnimationsHaveFinished()){
			restartLevel ();
		}
	}

	private void player1Wins(){
		hudManagerScript.startPlayer1WinsAnimation ();
	}

	private void player2Wins(){
		hudManagerScript.startPlayer2WinsAnimation ();
	}

	private void goToGoldenGoal(){
		Debug.Log ("It's a draw!");
	}

	private void restartLevel(){
		Debug.Log ("Level would be restarted");
	}
}
