using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraFoodItems : MonoBehaviour {
    BaseExtraItem extra;
    public string EIname;
    public int price;
    public string desc;
    public string rarity;
    public string FdType;
    public GameObject player;
    public float ObjDist;

    // Use this for initialization
    void Awake () {
        extra = new BaseExtraItem ();
        player = GameObject.FindGameObjectWithTag ( "Player" );
        extra.ItemName = EIname;
        extra.FlavourText = desc;
        extra.ItemPrice = price;
        extra.ItemRarity = rarity;
  //      extra.FoodType = FdType;
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
