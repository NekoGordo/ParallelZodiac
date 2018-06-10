using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class HybridMovingState : HybridBaseState {

	public override BaseState HandleInput(GameObject character, Vector2 movement) {
		//TODO: If input == forward, move character
		//TODO: This is always moving the character forward
		character.transform.position += new Vector3(movement.x, 0, movement.y);
		return null;
	}
	// Update is called once per frame
	public override void StateUpdate (GameObject character) {

	}
}
