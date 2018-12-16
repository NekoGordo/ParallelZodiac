using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Interaction : MonoBehaviour {

    public GameObject player;
    public float ObjDist;
    public int Rock_health;
    public bool IsHands;
    public bool IsLowLevelMagic;
    public bool IsHeavyWeapon;
    public bool IsHighLevelMagic;
    int damage_ByHW;
    int damage_ByHM;
    int damage_ByLM;
    int damage_Byhands;
    private void Awake () {
        player = GameObject.FindGameObjectWithTag ( "Player" );
        Rock_health = Random.Range ( 2, 6 );
        damage_Byhands = Random.Range ( 3, 5 );
        damage_ByLM = Random.Range ( 3, 5 );
        damage_ByHW = Random.Range ( 4, 5 );
        damage_ByHM = Random.Range ( 4, 5 );
        IsHands = true;
    }

    void FixedUpdate () {
        if ( Input.GetKeyDown ( KeyCode.Keypad1 ) ) {
            IsLowLevelMagic = false;
            IsHighLevelMagic = false;
            IsHands = true;
            IsHeavyWeapon = false;
        }
        if ( Input.GetKeyDown ( KeyCode.Keypad2 ) ) {
            IsLowLevelMagic = true;
            IsHighLevelMagic = false;
            IsHands = false;
            IsHeavyWeapon = false;
        }
        if ( Input.GetKeyDown ( KeyCode.Keypad3 ) ) {
            IsLowLevelMagic = false;
            IsHighLevelMagic = true;
            IsHands = false;
            IsHeavyWeapon = false;
        }
        if ( Input.GetKeyDown ( KeyCode.Keypad4 ) ) {
            IsLowLevelMagic = false;
            IsHighLevelMagic = false;
            IsHands = false;
            IsHeavyWeapon = true;
        }
        ObjDist = Vector3.Distance ( this.gameObject.transform.position, player.transform.position );
        if ( ObjDist < 2.5 ) {
            if ( IsHands ) {
                if ( Input.GetKeyDown ( KeyCode.R ) ) {
                    Rock_health = Rock_health - damage_Byhands;
                    Debug.Log ( "damage done is " + damage_Byhands );
                    Debug.Log ( "remaining health for rock is " + Rock_health );

                    if ( Rock_health <= 0 ) {
                        Debug.Log ( "dead rock" );
                        Destroy ( this.gameObject );
                    }

                } 
            }
            if ( IsLowLevelMagic ) {
                if ( Input.GetKeyDown ( KeyCode.R ) ) {
                    Rock_health = Rock_health - damage_ByLM;
                    Debug.Log ( "damage done is " + damage_ByLM );
                    Debug.Log ( "remaining health for rock is " + Rock_health );

                    if ( Rock_health <= 0 ) {
                        Debug.Log ( "dead rock" );
                        Destroy ( this.gameObject );
                    }
                }
            }
            if ( IsHighLevelMagic ) {
                if ( Input.GetKeyDown ( KeyCode.R ) ) {
                    Rock_health = Rock_health - damage_ByHM;
                    Debug.Log ( "damage done is " + damage_ByHM );
                    Debug.Log ( "remaining health for rock is " + Rock_health );

                    if ( Rock_health <= 0 ) {
                        Debug.Log ( "dead rock" );
                        Destroy ( this.gameObject );
                    }
                }
            }
            if ( IsHeavyWeapon ) {
                if ( Input.GetKeyDown ( KeyCode.R ) ) {
                    Rock_health = Rock_health - damage_ByHW;
                    Debug.Log ( "damage done is " + damage_ByHW );
                    Debug.Log ( "remaining health for rock is " + Rock_health );

                    if ( Rock_health <= 0 ) {
                        Debug.Log ( "dead rock" );
                        Destroy ( this.gameObject );
                    }
                }
            } //else if ( !IsHands || !IsHighLevelMagic || !IsLowLevelMagic || IsHeavyWeapon ) {
               // Debug.Log ( "Can't do shit  boi" );
             else if ( ObjDist > 2.6 ) {
                if ( Input.GetKeyDown ( KeyCode.R ) ) {
                    Debug.Log ( "no rock" );
                }
            }
        }
    }
}
