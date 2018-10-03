using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourEnchancment : MonoBehaviour {

    BaseArmourEnhancement ArEnchancment;
    public string Arname;
    public int price;
    public string desc;
    public string rarity;
    public GameObject player;
    public float ObjDist;

    // Use this for initialization
    void Awake () {
        ArEnchancment = new BaseArmourEnhancement ();
        player = GameObject.FindGameObjectWithTag ( "Player" );
        ArEnchancment.ArmourEnhanceName= Arname;
        ArEnchancment.FlavourText = desc;
        ArEnchancment.ItemPrice = price;
        ArEnchancment.Itemrarity = rarity;
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
