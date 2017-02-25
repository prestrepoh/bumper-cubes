using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour {

	public GameObject hudCanvas;

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
}
