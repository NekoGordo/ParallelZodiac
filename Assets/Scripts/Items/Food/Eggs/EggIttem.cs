using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggIttem : MonoBehaviour {
    BaseEggItem egg;
    public string Ename;
    public int price;
    public string desc;
    public string rarity;
    public bool dEgg;
    public string dragonType;
    public GameObject player;
    public float ObjDist;

    // Use this for initialization
    void Awake () {
        egg = new BaseEggItem ();
        player = GameObject.FindGameObjectWithTag ( "Player" );
        egg.EggName = Ename;
        egg.FlavourText = desc;
        egg.ItemPrice = price;
        egg.ItemRarity = rarity;
        egg.iSDragon = dEgg;
        if(dEgg == true ) {
            egg.WhichDragon = dragonType;
        }
    }

    void FixedUpdate () {
        ObjDist = Vector3.Distance ( this.gameObject.transform.position, player.transform.position );
        if ( ObjDist < 2.5 ) {
            if ( Input.GetKeyDown ( KeyCode.E ) ) {
                if ( dEgg ) {
                    Debug.Log ( "this is a dragons egg" );
                } else {
                    Debug.Log ( "hay theres a item" );
                }
            }
        } else if ( ObjDist > 2.6 ) {
            if ( Input.GetKeyDown ( KeyCode.E ) ) {
                Debug.Log ( "notting here" );
            }
        }
    }
}
