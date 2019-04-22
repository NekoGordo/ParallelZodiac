using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantItem : MonoBehaviour {

    BasePlantItem plant;
    public string Pname;
    public int price;
    public string desc;
    public string rarity;
    public string FdType;
    public GameObject player;
    public float ObjDist;

    // Use this for initialization
    void Awake () {
        plant = new BasePlantItem ();
        player = GameObject.FindGameObjectWithTag ( "Player" );
        plant.PlantName = Pname;
        plant.FlavourText = desc;
        plant.ItemPrice = price;
        plant.Itemrarity = rarity;
//        plant.FoodType = FdType;
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
