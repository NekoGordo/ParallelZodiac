using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HybridMoveCommands : HybridCommand {

	public override HybridBaseState Execute(GameObject objectToActUpon, HybridCommand command)
	{
		Action(objectToActUpon);
		CharacterHybridController.AddCommandToReplayList(command);

		return new HybridMovingState ();
	}

	public override void Undo(GameObject objectToActUpon)
	{
		objectToActUpon.transform.Translate(-objectToActUpon.transform.forward * MoveDistance);
	}

	protected override void Action(GameObject objectToActUpon)
	{
		objectToActUpon.transform.Translate(objectToActUpon.transform.forward * MoveDistance);
	}
}