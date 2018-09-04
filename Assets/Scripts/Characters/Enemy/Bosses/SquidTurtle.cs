using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidTurtle : Enemy {
    //scripts
    MonsterStat mon;
    //mods
    public int HPMod = 150;
    public int ADMod = 50;
    public int DFMod = 50;
    public int APMod = 50;
    public int MDMod = 50;
    //stats
    public int MBForce = 30;
    public int MBVitality = 28;
    public int MBAgility = 31;
    public int MBFortitude = 30;
    public int MBIntellect = 27;
    public int MBRational = 32;
    public int MBCharima = 29;

    private void Awake()
    {
        CreateSignNumber();

        mon = new MonsterStat();

        myStats.Name = "SquidTurtle";
        myStats.Force = mon.Force + MBForce;
        myStats.Vitality = mon.Vitality + MBVitality;
        myStats.Agility = mon.Agility + MBAgility;
        myStats.Fortiude = mon.Fortiude + MBFortitude;
        myStats.Intellect = mon.Intellect + MBIntellect;
        myStats.Rationale = mon.Rationale + MBRational;
        myStats.Charisma = mon.Charisma + MBCharima;

        myStats.HealthPoints = (myStats.Vitality + myStats.Fortiude + HPMod) / 2;
        myStats.AbilityPoints = (myStats.Force + myStats.Intellect + APMod) / 2;
        myStats.Defence = myStats.Vitality + DFMod;
        myStats.AttackDamage = myStats.Force + ADMod;
        myStats.AttackSpeed = myStats.Agility;
        myStats.MagicDefence = myStats.Rationale + MDMod;

        myStats.AttackBar = 0 / 100;

        //HPthing
        myStats.MaximumHealthPoints = myStats.HealthPoints;
        myStats.HealthPoints = myStats.MaximumHealthPoints;
        //clamps it
        myStats.HealthPoints = Mathf.Clamp(myStats.HealthPoints, 0, myStats.MaximumHealthPoints);


        // AP bar increasre by timesing agility by time.deltatime
        // divide delta time * agility by 32 
    }

    public SquidTurtle () {
        
    }
}
