using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourItems : MonoBehaviour {

    BaseArmourItem armour;
    public string Aname;
    public int price;
    public string desc;
    public string rarity;
    public string ArType;
    public GameObject player;
    public float ObjDist;

    // Use this for initialization
    void Awake () {
        armour = new BaseArmourItem();
        player = GameObject.FindGameObjectWithTag ( "Player" );
        armour.ArmourName = Aname;
        armour.FlavourText = desc;
        armour.ItemPrice = price;
        armour.ItemRarity = rarity;
        armour.ArmourType = ArType;
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
