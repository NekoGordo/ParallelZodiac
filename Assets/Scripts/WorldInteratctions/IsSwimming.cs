using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsSwimming : MonoBehaviour {

    private void OnTriggerStay ( Collider other ) {
        if ( other.name == "WaterBasicDaytime" ) {
            gameObject.GetComponentInParent<InputTesting> ().isSwimming = true;
        }
    }

    void OnTriggerExit ( Collider other ) {
        if ( gameObject.GetComponentInParent<InputTesting> ().isSwimming == true) {
            gameObject.GetComponentInParent<InputTesting> ().isSwimming = false;
        }
    }
}
