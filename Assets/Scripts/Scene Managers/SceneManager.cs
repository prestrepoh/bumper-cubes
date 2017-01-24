using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager{

	private int player1Score = 0;
	private int player2Score = 0;

	public void scoreGoalForPlayer1(){
		this.player1Score++;
	}

	public void scoreGoalForPlayer2(){
		this.player2Score++;
	}
}
