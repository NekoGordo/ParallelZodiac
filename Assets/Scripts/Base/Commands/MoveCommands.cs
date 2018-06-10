using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommands : Command {

	public class MoveForward : Command
	{
		public override void Execute(GameObject objectToActUpon, Command command)
		{
			Action(objectToActUpon);
			CharacterCommandController.AddCommandToReplayList(command);
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


	public class MoveReverse : Command
	{
		public override void Execute(GameObject objectToActUpon, Command command)
		{
			Action(objectToActUpon);
			CharacterCommandController.AddCommandToReplayList(command);
		}

		public override void Undo(GameObject objectToActUpon)
		{
			objectToActUpon.transform.Translate(objectToActUpon.transform.forward * MoveDistance);
		}

		protected override void Action(GameObject objectToActUpon)
		{
			objectToActUpon.transform.Translate(-objectToActUpon.transform.forward * MoveDistance);
		}
	}


	public class MoveLeft : Command
	{
		public override void Execute(GameObject objectToActUpon, Command command)
		{
			Action(objectToActUpon);
			CharacterCommandController.AddCommandToReplayList(command);
		}

		public override void Undo(GameObject objectToActUpon)
		{
			objectToActUpon.transform.Translate(objectToActUpon.transform.right * MoveDistance);
		}

		protected override void Action(GameObject objectToActUpon)
		{
			objectToActUpon.transform.Translate(-objectToActUpon.transform.right * MoveDistance);
		}
	}


	public class MoveRight : Command
	{
		public override void Execute(GameObject objectToActUpon, Command command)
		{
			Action(objectToActUpon);
			CharacterCommandController.AddCommandToReplayList(command);
		}

		public override void Undo(GameObject objectToActUpon)
		{
			objectToActUpon.transform.Translate(-objectToActUpon.transform.right * MoveDistance);
		}

		protected override void Action(GameObject objectToActUpon)
		{
			objectToActUpon.transform.Translate(objectToActUpon.transform.right * MoveDistance);
		}
	}
}
