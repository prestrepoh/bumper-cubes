using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneManager{

	private static int player1Score;
	private static int player2Score;

	public static void scoreGoalForPlayer1(){
		player1Score++;
		Debug.Log("Goal Scored - score:" + player1Score + "-" + player2Score);
	}

	public static void scoreGoalForPlayer2(){
		player2Score++;
		Debug.Log("Goal Scored - score:" + player1Score + "-" + player2Score);
	}
}

