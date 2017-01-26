using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	
	public GameObject player1ScoreText;
	public GameObject player2ScoreText;

	public void setPlayer1ScoreText(int goals){
		player1ScoreText.GetComponent <Text> ().text = goals.ToString ();
	}

	public void setPlayer2ScoreText(int goals){
		player2ScoreText.GetComponent <Text> ().text = goals.ToString ();
	}
}
