using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllAnimationsFinishedBehavior : StateMachineBehaviour {

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetBool ("AllAnimationsFinished",true);
	}
}
