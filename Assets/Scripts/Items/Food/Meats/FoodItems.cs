using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItems : MonoBehaviour {
    BaseMeatItem meat;
    public string Mname;
    public int price;
    public string desc;
    public string rarity;
    public string FdType;
    public GameObject player;
    public float ObjDist;

    // Use this for initialization
         void Awake () {
            meat = new BaseMeatItem ();
        player = GameObject.FindGameObjectWithTag ( "Player" );
        meat.MeatName = Mname;
            meat.FlavourText = desc;
            meat.ItemPrice = price;
            meat.ItemWorth = rarity;
            meat.FoodType = FdType;
        }

    void FixedUpdate () {
        ObjDist = Vector3.Distance ( this.gameObject.transform.position, player.transform.position );
        if ( ObjDist < 2.5 ) {
            if ( Input.GetKeyDown ( KeyCode.E ) ) {
                Debug.Log ( "hay theres a item" );

            }
    }else if(ObjDist > 2.6 ) {
            if ( Input.GetKeyDown ( KeyCode.E ) ) {
                Debug.Log ( "notting here" );
            }
        }
    }
}
