using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactiInteraaction : MonoBehaviour {

    public GameObject player;
    public float ObjDist;
    public int rng;

    private void Awake () {
        player = GameObject.FindGameObjectWithTag ( "Player" );
    }

    void FixedUpdate () {
        ObjDist = Vector3.Distance ( this.gameObject.transform.position, player.transform.position );
        if ( Input.GetKeyDown ( KeyCode.F ) ) {
            rng = Random.Range ( 1, 3 );
            Debug.Log ( rng );
            if ( ObjDist < 2.5 ) {
                if ( rng == 1 ) {
                    Debug.Log ( "you have destoryed a cactus now heres a item oh and by the way you take some damage ether 30 or3%" );
                    Destroy ( this.gameObject );
                }
                else if ( rng == 2 )
                    Debug.Log ( "you faild to destory the cactus now take 30 or 3% damage" );
            } else if ( ObjDist > 2.6 ) {
                //Debug.Log ( "nothing here" );
            }
        }
    }
}

