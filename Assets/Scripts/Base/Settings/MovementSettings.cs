using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSettings : MonoBehaviour {

	//[Serializable]
	public class BasicSettings
	{
		private static BasicSettings singleton = null;

		public float ForwardSpeed = 8.0f;   // Speed when walking forward
		public float BackwardSpeed = 4.0f;  // Speed when walking backwards
		public float StrafeSpeed = 4.0f;    // Speed when walking sideways
		public float RunMultiplier = 2.0f;   // Speed when sprinting
		public KeyCode RunKey = KeyCode.LeftShift;
		[HideInInspector] public float CurrentTargetSpeed = 8f;

		private bool m_Running;

		public BasicSettings() {
			
		}

		public static BasicSettings GetSingleton() {
			if (singleton == null)
				singleton = new BasicSettings ();
			
			return singleton;
		}

		public void UpdateDesiredTargetSpeed(Vector2 input)
		{
			if (input == Vector2.zero) return;
			if (input.x > 0 || input.x < 0)
			{
				//strafe
				CurrentTargetSpeed = StrafeSpeed;
			}
			if (input.y < 0)
			{
				//backwards
				CurrentTargetSpeed = BackwardSpeed;
			}
			if (input.y > 0)
			{
				//forwards
				//handled last as if strafing and moving forward at the same time forwards speed should take precedence
				CurrentTargetSpeed = ForwardSpeed;
			}

			if (Input.GetKey(RunKey))
			{
				CurrentTargetSpeed *= RunMultiplier;
				m_Running = true;
			}
			else
			{
				m_Running = false;
			}
		}

		public bool Running
		{
			get { return m_Running; }
		}
	}


	//[Serializable]
	public class AdvancedSettings
	{
		private static AdvancedSettings singleton = null;

		public float groundCheckDistance = 0.01f; // distance for checking if the controller is grounded ( 0.01f seems to work best for this )
		public float stickToGroundHelperDistance = 0.5f; // stops the character
		public float slowDownRate = 20f; // rate at which the controller comes to a stop when there is no input
		public bool airControl; // can the user control the direction that is being moved in the air
		[Tooltip("set it to 0.1 or more if you get stuck in wall")]
		public float shellOffset; //reduce the radius by that ratio to avoid getting stuck in wall (a value of 0.1f is nice)

		public AdvancedSettings() {
			
		}

		public static AdvancedSettings GetSingleton() {
			if (singleton == null)
				singleton = new AdvancedSettings ();
			
			return singleton;
		}
	}
}
