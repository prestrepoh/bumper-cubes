using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public GameObject soundContainer;
	AudioSource ambient;
	AudioSource goal;
	AudioSource missGoal;
	AudioSource startGame;

	void Awake () {
		AudioSource[] soundList = soundContainer.GetComponents<AudioSource>(); //GetComponents<AudioSource>()
		ambient = soundList[0];
		goal = soundList[1];
		missGoal = soundList[2];
		startGame = soundList[3];
	}

	public void playAmbientSound() {
		ambient.loop = true;
		ambient.Play();
	}

	public void playGoalSound() {
		goal.Play();
	}

	public void playMissGoalSound() {
		missGoal.Play();
	}

	public void playStarGameSound() {
		startGame.Play();
	}
}
