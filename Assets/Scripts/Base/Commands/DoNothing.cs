using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNothing : Command {

	public override void Execute (GameObject objectToActUpon, Command command)
	{
		//Do nothing, assign this to keys that should do nothing?
		//Will that be necessary?
	}
}
