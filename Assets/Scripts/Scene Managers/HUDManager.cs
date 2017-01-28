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

	public bool allAnimationsHaveFinished(){
		return hudCanvasAnimator.GetBool ("AllAnimationsFinished");
	}
}
