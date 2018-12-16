using UnityEngine;
using System.Collections;

public class PointRot: MonoBehaviour {

	private float currentX = 0.0f;
	public float sensitvityX = 4.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		currentX += Input.GetAxis ("Mouse X") * sensitvityX * Time.deltaTime;
	}

	private void LateUpdate(){
		Quaternion rotation = Quaternion.Euler (0, currentX, 0);
	}
}
