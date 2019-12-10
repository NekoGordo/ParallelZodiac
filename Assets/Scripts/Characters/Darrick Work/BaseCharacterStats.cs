using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @author Darrick Hilburn
 * Stats universal across characters are kept here
 * Different character objects will have this script on
 * them.
 */
public class BaseCharacterStats
{
    public string Name;
    public int Force;
    public int Vitality;
    public int Agility;
    public int Fortiude;
    public int Intellect;
    public int Rationale;
    public int Charisma;

    public float AbilityPoints; //abillity points(magic damage)
    public float AttackDamage;  //attack damage
    public float MoralPoints;   //moral points
    public float Defence;
    public float MagicDefence;  //magic deffence
    public float AttackSpeed;   //attack speed
    public float TravelStamina; //helps with trvels
    public float HealthPoints;
    public float MaximumHealthPoints = 0;
    public float MaximumAttackBar;
    public float MaximumAbilityPoints = 0;
    public float AttackBar;
}
