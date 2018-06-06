using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RunState : MovingState {

	//TODO: Vars related to this
	// Ie, max speed, accel speed, etc
	// Maybe take apart the FPS or TPS controller for this?

	public override BaseState HandleInput(GameObject character) {
		//TODO: If input == forward, move character
		//TODO: Make sure this calls the MovingState's function
		BaseState tempState = null;
		tempState = base.HandleInput (character);
		//TODO: Need to do some state logic
		return tempState;
	}
	// Update is called once per frame
	public override void StateUpdate (GameObject character) {
		base.StateUpdate (character);
	}
}
