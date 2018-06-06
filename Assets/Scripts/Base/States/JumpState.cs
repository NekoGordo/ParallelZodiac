using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class JumpState : MovingState {

	//TODO: Jumping logic
	//IE, jump time, accel, etc
	private float JumpForce = 30f;
	private bool PreviouslyGrounded, Jumping, IsGrounded;

	private Rigidbody CharacterRigidBody;
	private CapsuleCollider CharacterCapsule;

	MovementSettings.AdvancedSettings AdvancedSettings;
	MovementSettings.BasicSettings BasicSettings;


	public JumpState() {
		CharacterRigidBody = null;
		AdvancedSettings = MovementSettings.AdvancedSettings.GetSingleton();
		BasicSettings = MovementSettings.BasicSettings.GetSingleton();
	}

	public override BaseState HandleInput(GameObject character) {
		//TODO: Make sure this calls the MovingState's function
		BaseState tempState = null;
		tempState = base.HandleInput (character);
		//TODO: Need to do some state logic
		if (Jumping == false) tempState = new IdleState();
		return tempState;
	}
	// Update is called once per frame
	public override void StateUpdate (GameObject character) {
		if (CharacterRigidBody == null)
			CharacterRigidBody = character.GetComponent<Rigidbody> ();
		if(CharacterCapsule == null)
			CharacterCapsule = character.GetComponent<CapsuleCollider>();

		GroundCheck(character.GetComponent<Transform>());

		if (IsGrounded)
		{		
			CharacterRigidBody.drag = 5f;
			Vector2 input = base.GetInput();
			BasicSettings.UpdateDesiredTargetSpeed(input);

			CharacterRigidBody.drag = 0f;
			CharacterRigidBody.velocity = new Vector3(CharacterRigidBody.velocity.x, 0f, CharacterRigidBody.velocity.z);
			CharacterRigidBody.AddForce(new Vector3(0f, JumpForce, 0f), ForceMode.Impulse);
			Jumping = true;

			if (!Jumping && Mathf.Abs(input.x) < float.Epsilon && Mathf.Abs(input.y) < float.Epsilon && CharacterRigidBody.velocity.magnitude < 1f)
			{
				CharacterRigidBody.Sleep();
			}
		}
		else
		{
			CharacterRigidBody.drag = 0f;
			if (PreviouslyGrounded && !Jumping)
			{
				//((UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController)GetComponent("RigidbodyFirstPersonController")).StickToGroundHelper();
			}
		}

		base.StateUpdate (character);
	}

	/// sphere cast down just beyond the bottom of the capsule to see if the capsule is colliding round the bottom
	private void GroundCheck(Transform transform)
	{
		PreviouslyGrounded = IsGrounded;
		RaycastHit hitInfo;
		if (Physics.SphereCast(transform.position, CharacterCapsule.radius * (1.0f - AdvancedSettings.shellOffset), Vector3.down, out hitInfo,
			((CharacterCapsule.height/2f) - CharacterCapsule.radius) + AdvancedSettings.groundCheckDistance, Physics.AllLayers, QueryTriggerInteraction.Ignore))
		{
			IsGrounded = true;
		}
		else
		{
			IsGrounded = false;
		}
		if (!PreviouslyGrounded && IsGrounded && Jumping)
		{
			Jumping = false;
		}
	}
}
