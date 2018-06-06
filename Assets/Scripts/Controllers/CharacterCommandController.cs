using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCommandController : MonoBehaviour {

	public GameObject Character;	//TODO: Get character
	Transform CharacterOriginalTransform;

	Command SpaceBar, KeyW, KeyA, KeyS, KeyD, KeyZ, KeyR; //KeyB
	public static List<Command> OldCommands;

	public static bool ShouldStartReplay;
	private Coroutine ReplayCoroutine;
	private static bool ReplayMode;

	// Use this for initialization
	void Start () {
		OldCommands = new List<Command>();

		SpaceBar = new JumpCommand ();

		KeyW = new MoveCommands.MoveForward ();
		KeyA = new MoveCommands.MoveLeft();
		KeyS = new MoveCommands.MoveReverse();
		KeyD = new MoveCommands.MoveRight();

		KeyZ = new ControlCommands.UndoCommand ();
		KeyR = new ControlCommands.ReplayCommand ();

		ReplayMode = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!ReplayMode) 
		{
			HandleInput ();
		}

		StartReplay ();
	}

	void HandleInput() 
	{
		//TODO: Break into chunks of actions that can be performed at the same time, ie movmenet actions, attack actions, etc
		if (Input.GetKeyDown(KeyCode.W))
		{
			KeyW.Execute(Character, KeyW);
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			KeyA.Execute(Character, KeyA);
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			KeyS.Execute(Character, KeyS);
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			KeyD.Execute (Character, KeyD);
		}
		//TODO: Ensure the following cant be pressed at the same time as an action
		else if (Input.GetKeyDown (KeyCode.R)) {
			KeyR.Execute (Character, KeyR);
		} else if (Input.GetKeyDown (KeyCode.Z)) {
			KeyZ.Execute (Character, KeyZ);
		} else {
			//No keys pushed
			//new IdleCommand().Execute();
		}
		/*else if (Input.GetKeyDown(KeyCode.B))
		{
			KeyB.Execute(KeyB);
		}*/
	}

	public void ChangeCommandKeyBind(KeyCode key, Command command) {
		//switch with KeyCodes, then set appropriately 
	}

	void StartReplay()
	{
		if (ShouldStartReplay && OldCommands.Count > 0)
		{
			ShouldStartReplay = false;

			//Stop the coroutine so it starts from the beginning
			if (ReplayCoroutine != null)
			{
				StopCoroutine(ReplayCoroutine);
			}

			ReplayCoroutine = StartCoroutine(ReplayCommands(Character));
		}
	}

	IEnumerator ReplayCommands(GameObject objectToReplay)
	{
		ReplayMode = true;

		objectToReplay.transform.position = objectToReplay.transform.position;
		objectToReplay.transform.rotation = objectToReplay.transform.rotation;

		//TODO: A way to stop replay in action, and reset to current state

		for (int i = 0; i < OldCommands.Count; i++)
		{
			OldCommands[i].Execute(Character, OldCommands[i]);
			//TODO: This should eventually be replaced
			//When performing a command, get the timestamp of the command and save it, then perform commands based on that
			//Maybe instead of timestamp, time since last command, or time since game start? 
			yield return new WaitForSeconds(0.3f);
		}
		ReplayMode = false;
	}

	public static void AddCommandToReplayList(Command command)
	{
		if(!ReplayMode)
			OldCommands.Add(command);
	}
}


