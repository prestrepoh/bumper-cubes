using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class SceneManager : MonoBehaviour {

	private int player1Score;
	private int player2Score;
	private bool gameHasEnded;
	private bool goldenGoal;

	private ScoreManager scoreManagerScript; 
	private HUDManager hudManagerScript;
	private SceneStartManager sceneStartManagerScript;
	private SoundManager soundManagerScript;

	void Start () {
		player1Score = 0;
		player2Score = 0;
		gameHasEnded = false;
		goldenGoal = false;

		scoreManagerScript = gameObject.GetComponentInParent<ScoreManager>();
		hudManagerScript = gameObject.GetComponent<HUDManager> ();
		sceneStartManagerScript = gameObject.GetComponent<SceneStartManager> ();
		soundManagerScript = gameObject.GetComponentInParent<SoundManager>( );

		// Initializer
		componentsInitializer();
	}

	/**
	 * Method in charge of initializing the transversal components for the game
	 */
	void componentsInitializer() {
		soundManagerScript.playStarGameSound ();
		soundManagerScript.playAmbientSound ();
	}

	public void scoreGoalForPlayer1(){
		player1Score++;
		scoreManagerScript.setPlayer1ScoreText (player1Score);
		if (!goldenGoal) {
			restartSceneElementsPosition ();
		}
		generalGoal ();
	}

	public void scoreGoalForPlayer2(){
		player2Score++;
		scoreManagerScript.setPlayer2ScoreText (player2Score);
		if (!goldenGoal) {
			restartSceneElementsPosition ();
		}
		generalGoal ();
	}

	public void timeUp(){
		
		if (!gameHasEnded) {
			
			gameHasEnded = true;

			if (player1Score > player2Score) {
				player1Wins ();
			} else if (player2Score > player1Score) {
				player2Wins ();
			} else {
				hudManagerScript.playGoldenGoalAnimation ();
				goldenGoal = true;
			}
		}

		if(goldenGoal){
			if (player1Score > player2Score) {
				goldenGoal = false;
				player1Wins ();
			} else if (player2Score > player1Score) {
				goldenGoal = false;
				player2Wins ();
			}
		}

		if(hudManagerScript.allAnimationsHaveFinished()){
			restartMatch ();
		}
	}

	private void player1Wins(){
		hudManagerScript.startPlayer1WinsAnimation ();
	}

	private void player2Wins(){
		hudManagerScript.startPlayer2WinsAnimation ();
	}

	private void goToGoldenGoal(){
		hudManagerScript.playGoldenGoalAnimation ();
	}

	private void restartSceneElementsPosition(){
		sceneStartManagerScript.resetPlayersTransform ();
		sceneStartManagerScript.setBallToInitialState ();
	}

	private void restartMatch(){
		player1Score = 0;
		player2Score = 0;
		gameHasEnded = false;
		goldenGoal = false;
		hudManagerScript.restartAnimatorStatus ();
		sceneStartManagerScript.restartScene ();
	}


	/**
	 * Method responsible for firing events at the time of a goal at any goal
	 */
	void generalGoal() {
		soundManagerScript.playGoalSound ();
	}

	public void missGoalSound() {
		soundManagerScript.playMissGoalSound ();
	}
}
