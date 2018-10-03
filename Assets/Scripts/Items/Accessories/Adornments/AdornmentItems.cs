using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdornmentItems : MonoBehaviour {

    BaseAdornmentItems adornmens;
    public string Adname;
    public int price;
    public string desc;
    public string rarity;
    public string AdType;
    public GameObject player;
    public float ObjDist;

    // Use this for initialization
    void Awake () {
        adornmens = new BaseAdornmentItems ();
        player = GameObject.FindGameObjectWithTag ( "Player" );
        adornmens.AdornmentName = Adname;
        adornmens.FlavourText = desc;
        adornmens.ItemPrice = price;
        adornmens.Itemrarity = rarity;
        adornmens.AdornmentType = AdType;
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
