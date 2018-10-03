using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsItems : MonoBehaviour {

    BaseWeaponItems weapon;
    public string Wname;
    public int price;
    public string desc;
    public string rarity;
    public string WpType;
    public GameObject player;
    public float ObjDist;

    // Use this for initialization
    void Awake () {
        weapon = new BaseWeaponItems ();
        player = GameObject.FindGameObjectWithTag ( "Player" );
        weapon.WeaponName = Wname;
        weapon.FlavourText = desc;
        weapon.ItemPrice = price;
        weapon.Itemrarity = rarity;
        weapon.WeaponType = WpType;
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
