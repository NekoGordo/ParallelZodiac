using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsSwimming : MonoBehaviour {

    public bool isSwimming = false;

    private void OnTriggerStay ( Collider other ) {
        if ( other.name == "WaterBasicDaytime" ) {
            isSwimming= true;
        }
    }

    void OnTriggerExit ( Collider other ) {
        if ( isSwimming) {
            isSwimming = false;
        }
    }
}
