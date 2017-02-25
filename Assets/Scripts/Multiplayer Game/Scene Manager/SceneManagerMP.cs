using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class SceneManagerMP : NetworkBehaviour {
	
	const int playersPerGame = 2;

	[SyncVar(hook = "OnPlayer1ScoreChange")]
	private int player1Score;
	[SyncVar(hook = "OnPlayer2ScoreChange")]
	private int player2Score;
	[SyncVar]
	private bool serverTimeIsUp;
	[SyncVar]
	private bool serverHasEndedThegame;
	[SyncVar]
	private bool serverHasSetGoldenGoal;
	[SyncVar]
	private bool player1hasWon;
	[SyncVar]
	private bool player2hasWon;
	[SyncVar]
	private bool serverHasStartedThegame;
	[SyncVar]
	private int numberOfPlayersConnected;
	[SyncVar]
	private int numberOfPlayersReady;

	private bool localGameHasEnded;


	private SceneStartManagerMP sceneStartManagerMPScript;
	private HUDManagerMP HUDManagerMPScript;
	private LobbyManagerMP lobbyManagerMPScript;

	void Awake(){
		numberOfPlayersConnected = 0;
		numberOfPlayersReady = 0;
		serverHasStartedThegame = false;
		lobbyManagerMPScript = gameObject.GetComponent<LobbyManagerMP> ();
		//lobbyManagerMPScript.connectToMatch ();
	}

	void Start () {
		sceneStartManagerMPScript = gameObject.GetComponent<SceneStartManagerMP> ();
		HUDManagerMPScript  = gameObject.GetComponent<HUDManagerMP> ();

		localGameHasEnded = false;
		player1hasWon = false;
		player2hasWon = false;

		if (isServer) {
			serverTimeIsUp = false;
			serverHasEndedThegame = false;
			serverHasSetGoldenGoal = false;
			player1Score = 0;
			player2Score = 0;
			sceneStartManagerMPScript.setBallToInitialState ();
		}
	}

	void Update(){
		if (serverTimeIsUp) {
			//Check if someone has won. If not, set the golden goal
			if (isServer && !serverHasEndedThegame) {
				if (player1Score > player2Score) {
					player1hasWon = true;
					serverHasSetGoldenGoal = false;
				} 

				if (player2Score > player1Score) {
					player2hasWon = true;
					serverHasSetGoldenGoal = false;
				} 

				if(player1Score == player2Score){
					serverHasSetGoldenGoal = true;
				}

				serverHasEndedThegame = true;
			}

			if (isServer && serverHasSetGoldenGoal) {
				if (player1Score > player2Score) {
					player1hasWon = true;
					serverHasSetGoldenGoal = false;
				} 

				if(player2Score > player1Score) {
					serverHasSetGoldenGoal = false;
					player2hasWon = true;
				} 
			}

			if(serverHasSetGoldenGoal){
				HUDManagerMPScript.playGoldenGoalAnimation ();
			}

			if (player1hasWon && !localGameHasEnded) {
				localGameHasEnded = true;
				player1Wins ();
			}

			if (player2hasWon && !localGameHasEnded) {
				localGameHasEnded = true;
				player2Wins ();
			}
		}
	}

	public void PlayerConnectedToMatch(){
		if(!isServer){
			//CmdPlayerConnectedToMatch ();
		}
	}

	[Command]
	public void CmdPlayerConnectedToMatch(){
		numberOfPlayersConnected++;
		checkIfAllPlayersAreReady ();
		Debug.Log ("Number of players connected:" + numberOfPlayersConnected);
	}

	[Command]
	public void CmdPlayerReady(){
		numberOfPlayersReady++;
		checkIfAllPlayersAreReady ();
	}

	private void checkIfAllPlayersAreReady(){
		if(numberOfPlayersReady == playersPerGame && numberOfPlayersConnected == playersPerGame){
			serverHasStartedThegame = true;
		}
	}

	//This method is called by the timer when it reaches 0
	public void timeUp(){
		if (isServer) {
			serverTimeIsUp = true;
		}
	}

	public void scoreGoalForPlayer1(){
		if (isServer) {
			player1Score++;
		}
	}

	public void scoreGoalForPlayer2(){
		if (isServer) {
			player2Score++;
		}
	}

	void OnPlayer1ScoreChange(int player1Score){
		HUDManagerMPScript.setPlayer1ScoreText (player1Score);
	}

	void OnPlayer2ScoreChange(int player2Score){
		HUDManagerMPScript.setPlayer2ScoreText (player2Score);
	}

	private void player1Wins(){
		HUDManagerMPScript.startPlayer1WinsAnimation ();
	}

	private void player2Wins(){
		HUDManagerMPScript.startPlayer2WinsAnimation ();
	}

	private void endMatch(){
		Debug.Log ("Game has ended");
		if(isServer){
			Debug.Log ("I am the server, so I send the match final score to the server");
		}
	}
}
