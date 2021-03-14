using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text;

public class Enemy : BaseCharacterCombat{

    Combat_mk2 combat;

    //Combat combat;
    private void Start () {
        combat = GameObject.Find("GM").GetComponent<Combat_mk2>();
    }

    public void Attack()
    {
        //remake this code
    }

    public void EnemyTakeDamage () {
    }
}
