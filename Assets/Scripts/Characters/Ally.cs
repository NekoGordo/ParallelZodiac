using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Ally : BaseCharacterCombat
{
    //public static string BASIC_TYPE = "Ally";  //TODO:This instead of tags?
    //public static Material WalkZoneMaterial;
    Button btn;
    Combat_mk2 combat;


    private void Start () {
        combat = GameObject.Find ( "GM" ).GetComponent<Combat_mk2> ();
        
    }

    public void Attack(Enemy enemyToAttack)
    {

        //if ( hasAttacked )
           // DamageEnemy (enemyToAttack, (int)myStats.AttackDamage);
        //TODO: This code
    }
    public void DamageAlly () {
       // TakeDamage ((int)myStats.AttackDamage);
    }
}