using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.NetworkSystem;

public class LobbyManagerMP : NetworkBehaviour {
	//TODO:Hard coded for initial tests, until the login is built
	private string userName;
	
	public GameObject sceneNetworkManager;
	public GameObject sceneManager;

	private NetworkManager manager;

	private SceneManagerMP networkSceneManagerScript;

	public void connectToMatch(){
		
		manager = sceneNetworkManager.GetComponent<NetworkManager> ();

		networkSceneManagerScript = sceneManager.GetComponent<SceneManagerMP> ();

		userName = Random.Range(111111,999999).ToString();

		manager.StartMatchMaker ();
		//This function calls OnMatchList when it ends
		manager.matchMaker.ListMatches (0, 20, "", false, 0, 0, OnMatchList);
	}

	//ListMatches function callback
	private void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
	{
		if (matches.Count == 0) {
			manager.matchMaker.CreateMatch (userName, 2, true, "", "", "", 0, 0, OnMatchCreate);
		} else {
			manager.matchMaker.JoinMatch (matches [0].networkId, "", "", "", 0, 0, OnMatchJoined);
		}
	}

	//CreateMatch function callback
	private void OnMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
	{
		Debug.Log ("Match created!");
		networkSceneManagerScript.PlayerConnectedToMatch();
	}

	//JoinMatch function callback
	private void OnMatchJoined(bool success, string extendedInfo, MatchInfo matchInfo)
	{
		Debug.Log ("Joined a match!");
		networkSceneManagerScript.PlayerConnectedToMatch();
	}
}
