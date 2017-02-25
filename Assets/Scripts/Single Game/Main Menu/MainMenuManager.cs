using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	public void startSingleGame(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Game");
	}

	public void startMultiplayerGame(){
		Debug.Log ("Not yet implemented!");
	}

	public void showSettings(){
		Debug.Log ("Not yet implemented!");
	}
}
