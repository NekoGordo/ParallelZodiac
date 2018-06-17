using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text;

public class Enemy : BaseCharacter
{
    protected int SignNumber = 0; //TODO: Move to base?
    Combat combat;
    private void Start () {
        combat = GameObject.Find ( "GM" ).GetComponent<Combat> ();
    }
    public override void ReceivPriority()
    {
        Attack();
        CanAct = false;
        AttackBar = 0f;

        return;
    }

    public void Attack()
    {
        if(combat.CharacterWithPriority == -1 ) {
            return;
        }
        if (hasAttacked)
        {
          //TODO figure out how to find the correct player to attack. 
        }
        //TODO: That code
    }

    public void EnemyTakeDamage () {
    if ( EnemyAttacked )
        TakeDamage ( ( int ) AttackDamage );
    }

    protected void CreateSignNumber()
    {
        SignNumber = Random.Range(1, 14);
    }
}
