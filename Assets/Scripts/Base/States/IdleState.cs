using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class IdleState : BaseState {

	//TODO: Idle vars

	// Use this for initialization
	public override BaseState HandleInput(GameObject character) {
		BaseState stateToReturn = null;

		if (CrossPlatformInputManager.GetButtonDown ("Jump")) {
			stateToReturn = new JumpState ();
		}
		return stateToReturn;
	}

	//TODO: Use new keyword?
	public override void StateUpdate (GameObject character) {

		//To make sure this works
		int debug = 3;
		debug += 3;
		//base.Update (character);
	}
}
