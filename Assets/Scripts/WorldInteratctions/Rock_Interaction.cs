using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Interaction : MonoBehaviour {

    public GameObject player;
    public float ObjDist;

    private void Awake () {
        player = GameObject.FindGameObjectWithTag ( "Player" );
    }

    void FixedUpdate () {
        ObjDist = Vector3.Distance ( this.gameObject.transform.position, player.transform.position );
        if ( ObjDist < 2.5 ) {
            if ( Input.GetKeyDown ( KeyCode.F ) ) {
                Debug.Log ( "the rock might take abit to destroy" );
                Destroy ( this.gameObject );
            }
        } else if ( ObjDist > 2.6 ) {
            if ( Input.GetKeyDown ( KeyCode.F ) ) {
        //        Debug.Log ( "no rock" );
            }
        }
    }
}
