using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;

public class LobbyManager : NetworkBehaviour {
	
	//TODO:Hard coded for initial tests
	public GameObject statusText;

	private NetworkManager manager;

	//TODO:Hard coded for initial tests, until the login is built
	private string userName;


	void Awake()
	{

		manager = GetComponent<NetworkManager>();

		userName = Random.Range(111111,999999).ToString();

		manager.StartMatchMaker ();

		//This function calls OnMatchList when it ends
		manager.matchMaker.ListMatches (0, 20, "", false, 0, 0, OnMatchList);

	}

	//ListMatches function callback
	public void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
	{
		if (matches.Count == 0) {
			manager.matchMaker.CreateMatch (userName, 2, true, "", "", "", 0, 0, OnMatchCreate);
		} else {
			manager.matchMaker.JoinMatch (matches [0].networkId, "", "", "", 0, 0, OnMatchJoined);
		}
	}

	//CreateMatch function callback
	public void OnMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
	{
		Debug.Log ("Match created!");
		statusText.GetComponent <Text> ().text = "Match created!";
		manager.ServerChangeScene ("Multiplayer Game");
	}
	
	//JoinMatch function callback
	public void OnMatchJoined(bool success, string extendedInfo, MatchInfo matchInfo)
	{
		Debug.Log ("Joined a match!");
		statusText.GetComponent <Text> ().text = "Joined a match!";
	}
}
