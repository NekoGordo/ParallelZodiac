using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiro : Ally {

    public BaseAttack ba;
    Aquarius aqua;
    AssassinStats assassin;
    Experience exp;

    public int CBForce = 20;
    public int CBVitality = 23;
    public int CBAgility = 28;
    public int CBFortitude = 24;
    public int CBIntellect = 28;
    public int CBRational = 25;
    public int CBCharima = 24;
    
    //  public Attack attackChosen;
    //  public bool IsPlaying;

    private void Awake()
    {
        
        BasicType = "Ally";
        aqua = new Aquarius();
        ba = new BaseAttack();
        assassin = new AssassinStats();
        exp = new Experience("Being");
        MaximumAttackBar = 100 / 100;
        Name = "Shiro";
        Force = assassin.Force + aqua.Force + CBForce;
        Vitality = assassin.Vitality + aqua.Vitality + CBVitality;
        Agility = assassin.Agility + aqua.Agility + CBAgility;
        Fortiude = assassin.Fortiude + aqua.Fortitude + CBFortitude;
        Intellect = assassin.Intellect + aqua.Intellect + CBIntellect;
        Rationale = assassin.Rationale + aqua.Rational + CBRational;
        Charisma = assassin.Charisma + aqua.Charisma + CBCharima;
        MaximumHealthPoints = (Vitality + Fortiude) / 2;
        HealthPoints = MaximumHealthPoints;
        AbilityPoints = (Force + Intellect) / 2;
        MoralPoints = 100;
        TravelStamina = (Vitality / 2) + ((Fortiude / 4) / Rationale);
        Defence = Vitality;
        AttackDamage = Force;// this is for the damge
        AttackSpeed = Agility;
        MagicDefence = Rationale;

        //HPthing
        HealthPoints = MaximumHealthPoints;
        HealthPoints = Mathf.Clamp(HealthPoints, 0, MaximumHealthPoints);

        //i dont know if this is ment to be in this script
        ba.Damage = Random.Range(0, (int)AttackDamage) + 1;//this works out the random percent of the damage

        AttackBar = Mathf.Clamp(AttackBar, 0, MaximumAttackBar);
        // AP bar increasre by timesing agility by time.deltatime
        // divide delta time * agility by 32    
    }
}
