using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiro : Ally {

    public BaseAttack ba;
    Aquarius aqua;
    AssassinStats assassin;
    Experience exp;
    BaseStat bs;
    public CharacterStats myStats;


    public int CBForce = 20;
    public int CBVitality = 23;
    public int CBAgility = 28;
    public int CBFortitude = 24;
    public int CBIntellect = 28;
    public int CBRational = 25;
    public int CBCharima = 24;

    int count;
    
    //  public Attack attackChosen;
    //  public bool IsPlaying;

    private void Awake()
    {
       
        myStats = new CharacterStats();
        aqua = new Aquarius();
        ba = new BaseAttack();
        assassin = new AssassinStats();
        exp = new Experience("Being");

        myStats.Name = "Shiro";
        myStats.Force = assassin.Force + aqua.Force + CBForce;
        myStats.Vitality = assassin.Vitality + aqua.Vitality + CBVitality;
        myStats.Agility = assassin.Agility + aqua.Agility + CBAgility;
        myStats.Fortiude = assassin.Fortiude + aqua.Fortitude + CBFortitude;
        myStats.Intellect = assassin.Intellect + aqua.Intellect + CBIntellect;
        myStats.Rationale = assassin.Rationale + aqua.Rational + CBRational;
        myStats.Charisma = assassin.Charisma + aqua.Charisma + CBCharima;

        myStats.MaximumHealthPoints = (myStats.Vitality + myStats.Fortiude) / 2;
        myStats.HealthPoints = myStats.MaximumHealthPoints;
        myStats.AbilityPoints = (myStats.Force + myStats.Intellect) / 2;
        myStats.MoralPoints = 100;
        myStats.TravelStamina = (myStats.Vitality / 2) + ((myStats.Fortiude / 4) / myStats.Rationale);
        myStats.Defence = myStats.Vitality;
        myStats.AttackDamage = myStats.Force;// this is for the damge
        myStats.AttackSpeed = myStats.Agility;
        myStats.MagicDefence = myStats.Rationale;
    
        //HPthing
        myStats.HealthPoints = myStats.MaximumHealthPoints;
        myStats.HealthPoints = Mathf.Clamp(myStats.HealthPoints, 0, myStats.MaximumHealthPoints);

        //i dont know if this is ment to be in this script
        ba.Damage = Random.Range(0, (int)myStats.AttackDamage) + 1;//this works out the random percent of the damage

        myStats.AttackBar = Mathf.Clamp(myStats.AttackBar, 0, myStats.MaximumAttackBar);
        // AP bar increasre by timesing agility by time.deltatime
        // divide delta time * agility by 32    
    }
    void FixedUpdate()
    {
        if (count == 0)
        {
            count++;
            myStats.TotalAgility= aqua.Agility + CBAgility;
            print("shiro speed" + myStats.TotalAgility);


        }
        else if (count == 1)
            return;
    }
}
