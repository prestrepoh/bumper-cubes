using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

	private int player1Score;
	private int player2Score;
	private bool gameHasEnded;

	private ScoreManager scoreManagerScript; 


	void Start () {
		player1Score = 0;
		player2Score = 0;
		gameHasEnded = false;

		scoreManagerScript = gameObject.GetComponentInParent<ScoreManager>( );
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
		
		if(!gameHasEnded){
			
			gameHasEnded = true;

			if (player1Score > player2Score) {
				Debug.Log ("Player 1 wins!");
			} else if (player2Score > player1Score) {
				Debug.Log ("Player 2 wins!");
			} else {
				Debug.Log ("It's draw!");
			}
		}
	}
}
