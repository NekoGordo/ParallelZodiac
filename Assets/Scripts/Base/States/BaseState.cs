using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class BaseState {

	//TODO: Should this take in an Input argument?
	public virtual BaseState HandleInput(GameObject character) {
		//TODO: If input == forward, move character
		return null;
	}

	//TODO: Inherit this in other states? This will set transition animations and the like
	public virtual void EnterState() {

	}

	// Update is called once per frame
	public virtual void StateUpdate (GameObject character) {

	}

	protected virtual Vector2 GetInput()
	{
		Vector2 input = new Vector2
		{
			x = CrossPlatformInputManager.GetAxis("Horizontal"),
			y = CrossPlatformInputManager.GetAxis("Vertical")
		};
		return input;
	}
}
