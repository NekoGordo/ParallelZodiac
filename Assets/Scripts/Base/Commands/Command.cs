using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command {

	protected float MoveDistance = 1.0f;

	//TODO: Make these abstract?
	public virtual void Execute (GameObject objectToActUpon, Command command) {}
	protected virtual void Action (GameObject objectToActUpon) {}
	public virtual void Undo (GameObject objectToActUpon) {}
}
