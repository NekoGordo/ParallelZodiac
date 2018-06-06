using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Use this as a character controller?
public class CharacterStateController : MonoBehaviour {

	public GameObject Character;	//TODO: Get character
	BaseState CurrentState;

	// Use this for initialization
	void Start () {
		CurrentState = new IdleState ();
	}
	
	// Update is called once per frame
	void Update () {
		//if (Character == null)
		//	return;

		//TODO: Should I pass args instead of just grabbing them on the other side? Should I convert to an Input type and pass that?
		BaseState tempState = CurrentState.HandleInput (Character);
		CurrentState.StateUpdate (Character);

		if(tempState != null)
		{
			SetState (tempState);
			CurrentState.EnterState ();
		}
	}

	public void SetState(BaseState newState) {
		CurrentState = newState;
	}
}


