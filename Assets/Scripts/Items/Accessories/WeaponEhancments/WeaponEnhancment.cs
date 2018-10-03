using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnhancment : MonoBehaviour{

    BaseWeaponEnhancement WpEnchancment;
    public string Adname;
    public int price;
    public string desc;
    public string rarity;
    public GameObject player;
    public float ObjDist;

    // Use this for initialization
    void Awake () {
        WpEnchancment = new BaseWeaponEnhancement ();
        player = GameObject.FindGameObjectWithTag ( "Player" );
        WpEnchancment.WeaponEnhanceName = Adname;
        WpEnchancment.FlavourText = desc;
        WpEnchancment.ItemPrice = price;
        WpEnchancment.Itemrarity = rarity;
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
