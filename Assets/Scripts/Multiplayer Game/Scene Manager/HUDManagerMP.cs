using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManagerMP : MonoBehaviour {

	public GameObject hudCanvas;
	public GameObject player1ScoreText;
	public GameObject player2ScoreText;
	public GameObject debugText;

	private Animator hudCanvasAnimator;

	void Start () {
		hudCanvasAnimator = hudCanvas.GetComponent<Animator> ();
	}

	public void startPlayer1WinsAnimation(){
		hudCanvasAnimator.SetTrigger("player1Wins");
	}

	public void startPlayer2WinsAnimation(){
		hudCanvasAnimator.SetTrigger("player2Wins");
	}

	public void playGoldenGoalAnimation(){
		hudCanvasAnimator.SetBool ("goldenGoal",true);
	}

	public void stopGoldenGoalAnimation(){
		hudCanvasAnimator.SetBool("goldenGoal",false);
	}

	public bool allAnimationsHaveFinished(){
		return hudCanvasAnimator.GetBool ("AllAnimationsFinished");
	}

	public void restartAnimatorStatus(){
		hudCanvasAnimator.SetBool("AllAnimationsFinished",false);
		hudCanvasAnimator.SetBool("goldenGoal",false);
	}

	public void setPlayer1ScoreText(int goals){
		player1ScoreText.GetComponent <Text> ().text = goals.ToString ();
	}

	public void setPlayer2ScoreText(int goals){
		player2ScoreText.GetComponent <Text> ().text = goals.ToString ();
	}

	public void restartScoreTexts(){
		player1ScoreText.GetComponent <Text> ().text = "0";
		player2ScoreText.GetComponent <Text> ().text = "0";
	}

	public void setDebugText(string text){
		debugText.GetComponent <Text> ().text = text;
	}
}
