﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCactus : Enemy
{
    //scripts
    MonsterStat mon;
    Aquarius aqua;
    Aries arie;
    Cancer can;
    Capricorn cap;
    Gemini gem;
    Leo leo;
    Libra lib;
    Pisces pisc;
    Sagittarius sagi;
    Scorpio scrop;
    Serpentarius serp;
    Taurus taur;
    Virgo virg;
    //stats
    public int MBForce = 18;
    public int MBVitality = 23;
    public int MBAgility = 19;
    public int MBFortitude = 16;
    public int MBIntellect = 16;
    public int MBRational = 23;
    public int MBCharima = 22;

    private void Awake()
    {
        CreateSignNumber();

        mon = new MonsterStat();

        aqua = new Aquarius();
        arie = new Aries();
        can = new Cancer();
        cap = new Capricorn();
        gem = new Gemini();
        leo = new Leo();
        lib = new Libra();
        pisc = new Pisces();
        sagi = new Sagittarius();
        scrop = new Scorpio();
        serp = new Serpentarius();
        taur = new Taurus();
        virg = new Virgo();

        if (SignNumber == 1)
        {
            myStats.Name = "Fire Cactus";
            myStats.Force = mon.Force + aqua.Force + MBForce;
            myStats.Vitality = mon.Vitality + aqua.Vitality + MBVitality;
            myStats.Agility = mon.Agility + aqua.Agility + MBAgility;
            myStats.Fortiude = mon.Fortiude + aqua.Fortitude + MBFortitude;
            myStats.Intellect = mon.Intellect + aqua.Intellect + MBIntellect;
            myStats.Rationale = mon.Rationale + aqua.Rational + MBRational;
            myStats.Charisma = mon.Charisma + aqua.Charisma + MBCharima;
        }
        if (SignNumber == 2)
        {
            myStats.Name = "Fire Cactus";
            myStats.Force = mon.Force + arie.Force + MBForce;
            myStats.Vitality = mon.Vitality + arie.Vitality + MBVitality;
            myStats.Agility = mon.Agility + arie.Agility + MBAgility;
            myStats.Fortiude = mon.Fortiude + arie.Fortitude + MBFortitude;
            myStats.Intellect = mon.Intellect + arie.Intellect + MBIntellect;
            myStats.Rationale = mon.Rationale + arie.Rational + MBRational;
            myStats.Charisma = mon.Charisma + arie.Charisma + MBCharima;
        }
        if (SignNumber == 3)
        {
            myStats.Name = "Fire Cactus";
            myStats.Force = mon.Force + can.Force + MBForce;
            myStats.Vitality = mon.Vitality + can.Vitality + MBVitality;
            myStats.Agility = mon.Agility + can.Agility + MBAgility;
            myStats.Fortiude = mon.Fortiude + can.Fortitude + MBFortitude;
            myStats.Intellect = mon.Intellect + can.Intellect + MBIntellect;
            myStats.Rationale = mon.Rationale + can.Rational + MBRational;
            myStats.Charisma = mon.Charisma + can.Charisma + MBCharima;
        }
        if (SignNumber == 4)
        {
            myStats.Name = "Fire Cactus";
            myStats.Force = mon.Force + cap.Force + MBForce;
            myStats.Vitality = mon.Vitality + cap.Vitality + MBVitality;
            myStats.Agility = mon.Agility + cap.Agility + MBAgility;
            myStats.Fortiude = mon.Fortiude + cap.Fortitude + MBFortitude;
            myStats.Intellect = mon.Intellect + cap.Intellect + MBIntellect;
            myStats.Rationale = mon.Rationale + cap.Rational + MBRational;
            myStats.Charisma = mon.Charisma + cap.Charisma + MBCharima;
        }
        if (SignNumber == 5)
        {
            myStats.Name = "Fire Cactus";
            myStats.Force = mon.Force + gem.Force + MBForce;
            myStats.Vitality = mon.Vitality + gem.Vitality + MBVitality;
            myStats.Agility = mon.Agility + gem.Agility + MBAgility;
            myStats.Fortiude = mon.Fortiude + gem.Fortitude + MBFortitude;
            myStats.Intellect = mon.Intellect + gem.Intellect + MBIntellect;
            myStats.Rationale = mon.Rationale + gem.Rational + MBRational;
            myStats.Charisma = mon.Charisma + gem.Charisma + MBCharima;
        }
        if (SignNumber == 6)
        {
            myStats.Name = "Fire Cactus";
            myStats.Force = mon.Force + leo.Force + MBForce;
            myStats.Vitality = mon.Vitality + leo.Vitality + MBVitality;
            myStats.Agility = mon.Agility + leo.Agility + MBAgility;
            myStats.Fortiude = mon.Fortiude + leo.Fortitude + MBFortitude;
            myStats.Intellect = mon.Intellect + leo.Intellect + MBIntellect;
            myStats.Rationale = mon.Rationale + leo.Rational + MBRational;
            myStats.Charisma = mon.Charisma + leo.Charisma + MBCharima;
        }
        if (SignNumber == 7)
        {
            myStats.Name = "Fire Cactus";
            myStats.Force = mon.Force + lib.Force + MBForce;
            myStats.Vitality = mon.Vitality + lib.Vitality + MBVitality;
            myStats.Agility = mon.Agility + lib.Agility + MBAgility;
            myStats.Fortiude = mon.Fortiude + lib.Fortitude + MBFortitude;
            myStats.Intellect = mon.Intellect + lib.Intellect + MBIntellect;
            myStats.Rationale = mon.Rationale + lib.Rational + MBRational;
            myStats.Charisma = mon.Charisma + lib.Charisma + MBCharima;
        }
        if (SignNumber == 8)
        {
            myStats.Name = "Fire Cactus";
            myStats.Force = mon.Force + pisc.Force + MBForce;
            myStats.Vitality = mon.Vitality + pisc.Vitality + MBVitality;
            myStats.Agility = mon.Agility + pisc.Agility + MBAgility;
            myStats.Fortiude = mon.Fortiude + pisc.Fortitude + MBFortitude;
            myStats.Intellect = mon.Intellect + pisc.Intellect + MBIntellect;
            myStats.Rationale = mon.Rationale + pisc.Rational + MBRational;
            myStats.Charisma = mon.Charisma + pisc.Charisma + MBCharima;
        }
        if (SignNumber == 9)
        {
            myStats.Name = "Fire Cactus";
            myStats.Force = mon.Force + sagi.Force + MBForce;
            myStats.Vitality = mon.Vitality + sagi.Vitality + MBVitality;
            myStats.Agility = mon.Agility + sagi.Agility + MBAgility;
            myStats.Fortiude = mon.Fortiude + sagi.Fortitude + MBFortitude;
            myStats.Intellect = mon.Intellect + sagi.Intellect + MBIntellect;
            myStats.Rationale = mon.Rationale + sagi.Rational + MBRational;
            myStats.Charisma = mon.Charisma + sagi.Charisma + MBCharima;
        }
        if (SignNumber == 10)
        {
            myStats.Name = "Fire Cactus";
            myStats.Force = mon.Force + scrop.Force + MBForce;
            myStats.Vitality = mon.Vitality + scrop.Vitality + MBVitality;
            myStats.Agility = mon.Agility + scrop.Agility + MBAgility;
            myStats.Fortiude = mon.Fortiude + scrop.Fortitude + MBFortitude;
            myStats.Intellect = mon.Intellect + scrop.Intellect + MBIntellect;
            myStats.Rationale = mon.Rationale + scrop.Rational + MBRational;
            myStats.Charisma = mon.Charisma + scrop.Charisma + MBCharima;
        }
        if (SignNumber == 11)
        {
            myStats.Name = "Fire Cactus";
            myStats.Force = mon.Force + serp.Force + MBForce;
            myStats.Vitality = mon.Vitality + serp.Vitality + MBVitality;
            myStats.Agility = mon.Agility + serp.Agility + MBAgility;
            myStats.Fortiude = mon.Fortiude + serp.Fortitude + MBFortitude;
            myStats.Intellect = mon.Intellect + serp.Intellect + MBIntellect;
            myStats.Rationale = mon.Rationale + serp.Rational + MBRational;
            myStats.Charisma = mon.Charisma + serp.Charisma + MBCharima;
        }
        if (SignNumber == 12)
        {
            myStats.Name = "Fire Cactus";
            myStats.Force = mon.Force + taur.Force + MBForce;
            myStats.Vitality = mon.Vitality + taur.Vitality + MBVitality;
            myStats.Agility = mon.Agility + taur.Agility + MBAgility;
            myStats.Fortiude = mon.Fortiude + taur.Fortitude + MBFortitude;
            myStats.Intellect = mon.Intellect + taur.Intellect + MBIntellect;
            myStats.Rationale = mon.Rationale + taur.Rational + MBRational;
            myStats.Charisma = mon.Charisma + taur.Charisma + MBCharima;
        }
        if (SignNumber == 13)
        {
            myStats.Name = "Fire Cactus";
            myStats.Force = mon.Force + virg.Force + MBForce;
            myStats.Vitality = mon.Vitality + virg.Vitality + MBVitality;
            myStats.Agility = mon.Agility + virg.Agility + MBAgility;
            myStats.Fortiude = mon.Fortiude + virg.Fortitude + MBFortitude;
            myStats.Intellect = mon.Intellect + virg.Intellect + MBIntellect;
            myStats.Rationale = mon.Rationale + virg.Rationale + MBRational;
            myStats.Charisma = mon.Charisma + virg.Charisma + MBCharima;
        }

        myStats.HealthPoints = (myStats.Vitality + myStats.Fortiude) / 2;
        myStats.AbilityPoints = (myStats.Force + myStats.Intellect) / 2;
        myStats.Defence = myStats.Vitality;
        myStats.AttackDamage = myStats.Force;
        myStats.AttackSpeed = myStats.Agility;
        myStats.MagicDefence = myStats.Rationale;
        myStats.
                AttackBar = 0 / 100;

        //HPthing
        myStats.MaximumHealthPoints = myStats.HealthPoints;
        myStats.HealthPoints = myStats.MaximumHealthPoints;
        //clamps it
        myStats.HealthPoints = Mathf.Clamp(myStats.HealthPoints, 0, myStats.MaximumHealthPoints);


        // AP bar increasre by timesing agility by time.deltatime
        // divide delta time * agility by 32 
    }

    
}
