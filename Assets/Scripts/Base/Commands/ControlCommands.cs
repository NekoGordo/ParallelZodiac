using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCommands : Command {

	public class UndoCommand : Command
	{
		public override void Execute(GameObject objectToActUpon, Command command)
		{
			List<Command> oldCommands = CharacterCommandController.OldCommands;

			if (oldCommands.Count > 0)
			{
				Command latestCommand = oldCommands[oldCommands.Count - 1];

				latestCommand.Undo(objectToActUpon);
				oldCommands.RemoveAt(oldCommands.Count - 1);
			}
		}
	}

	public class ReplayCommand : Command
	{
		public override void Execute(GameObject objectToActUpon, Command command)
		{
			CharacterCommandController.ShouldStartReplay = true;
		}
	}
}
