using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    NPC = 0,
    ENEMY,
    ALLY,
    PLAYER
}

/**
 * @author Darrick Hilburn
 * CharacterStats is a container for stats all character instances
 * that derive from BaseCharacter use. * 
 */
public class CharacterStats : MonoBehaviour
{
    public CharacterType myType;

    public string Name;
    public int Force;
    public int Vitality;
    public int Agility;
    public int Fortiude;
    public int Intellect;
    public int Rationale;
    public int Charisma;

    public int TotalAgility;

    public float AbilityPoints; //abillity points(magic damage)
    public float AttackDamage;  //attack damage
    public float MoralPoints;   //moral points
    public float Defence;       //defence
    public float MagicDefence;  //magic deffence
    public float AttackSpeed;   //attack speed
    public float TravelStamina; //helps with trvels
    public float HealthPoints;  //hp
    public float MaximumHealthPoints;   //max hp
    public float MaximumAttackBar;  //max attack bar - redunent
    public float MaximumAbilityPoints;  //max ap
    public float AttackBar; //attack bar - redundent
}


