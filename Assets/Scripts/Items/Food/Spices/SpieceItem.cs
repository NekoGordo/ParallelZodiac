using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpieceItem : MonoBehaviour {
    BaseSpiceItem spice;
    public string Sname;
    public int price;
    public string desc;
    public string rarity;
    public string SpType;
    public GameObject player;
    public float ObjDist;

    // Use this for initialization
    void Awake () {
        spice = new BaseSpiceItem ();
        player = GameObject.FindGameObjectWithTag ( "Player" );
        spice.SpiceName = Sname;
        spice.FlavourText = desc;
        spice.ItemPrice = price;
        spice.ItemRarity = rarity;
        spice.SpiceType = SpType;
    }

    void FixedUpdate () {
        ObjDist = Vector3.Distance ( this.gameObject.transform.position, player.transform.position );
        if ( ObjDist < 2.5 ) {
            if ( Input.GetKeyDown ( KeyCode.E ) ) {
                Debug.Log ( "hay theres a item" );

            }
        } else if ( ObjDist > 2.6 ) {
            if ( Input.GetKeyDown ( KeyCode.E ) ) {
                Debug.Log ( "notting here" );
            }
        }
    }
}
