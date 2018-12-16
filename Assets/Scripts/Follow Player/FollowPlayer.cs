using UnityEngine;
using System.Collections;
[RequireComponent (typeof(Rigidbody))]
public class FollowPlayer : MonoBehaviour {

	Rigidbody rb;
	public Transform target; 
	public float moveSpeed; 
	public float rotationSpeed = 3;
	public Transform myTransform ; 
	public float distance;
	public float stop;
	private bool PlayerCloseEnough = false;

	void Awake(){
		myTransform = transform; 
	}

	void Start(){
		rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		distance = Vector3.Distance (myTransform.position, target.position);
		if (Vector3.Distance (target.position, myTransform.position) > distance) {
			PlayerCloseEnough = true;
		} else if (Vector3.Distance (target.position, myTransform.position) < distance){
			PlayerCloseEnough = false;
		}
		if (distance <= stop) {
			moveSpeed = 0;
		} else {
			moveSpeed = 3;
			var lookDir = target.position - myTransform.position;
			lookDir.y = 0; // zero the height difference
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation,
				Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime);
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
	}
}
