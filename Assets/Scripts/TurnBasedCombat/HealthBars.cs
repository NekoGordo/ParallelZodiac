using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBars : MonoBehaviour {

    public Camera mCam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt ( transform.position + mCam.transform.rotation * Vector3.forward, mCam.transform.rotation * Vector3.up );  
	}
}
