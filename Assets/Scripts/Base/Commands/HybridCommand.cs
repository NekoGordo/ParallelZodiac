using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HybridCommand {

	protected float MoveDistance = 1.0f;

	//TODO: Make these abstract?
	public virtual HybridBaseState Execute (GameObject objectToActUpon, HybridCommand command) {return new HybridBaseState();}
	protected virtual void Action (GameObject objectToActUpon) {}
	public virtual void Undo (GameObject objectToActUpon) {}
}
