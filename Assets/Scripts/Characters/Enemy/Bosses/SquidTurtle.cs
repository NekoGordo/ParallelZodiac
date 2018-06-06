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

        Name = "SquidTurtle";
        Force = mon.Force + MBForce;
        Vitality = mon.Vitality + MBVitality;
        Agility = mon.Agility + MBAgility;
        Fortiude = mon.Fortiude + MBFortitude;
        Intellect = mon.Intellect + MBIntellect;
        Rationale = mon.Rationale + MBRational;
        Charisma = mon.Charisma + MBCharima;

        HealthPoints = (Vitality + Fortiude + HPMod) / 2;
        AbilityPoints = (Force + Intellect + APMod) / 2;
        Defence = Vitality + DFMod;
        AttackDamage = Force + ADMod;
        AttackSpeed = Agility;
        MagicDefence = Rationale + MDMod;

        AttackBar = 0 / 100;

        //HPthing
        MaximumHealthPoints = HealthPoints;
        HealthPoints = MaximumHealthPoints;
        //clamps it
        HealthPoints = Mathf.Clamp(HealthPoints, 0, MaximumHealthPoints);


        // AP bar increasre by timesing agility by time.deltatime
        // divide delta time * agility by 32 
    }

    public SquidTurtle () {
        
    }
}
