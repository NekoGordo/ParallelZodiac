using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralDragon : Enemy
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
    public int MBForce = 30;
    public int MBVitality = 26;
    public int MBAgility = 31;
    public int MBFortitude = 30;
    public int MBIntellect = 27;
    public int MBRational = 32;
    public int MBCharima = 29;

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

        //TODO: These should be modifiers in different file. Then, when you give this a sign, it just gets the file with the same string as the sign, removing all but one of the ifs (and removing that if too
        if (SignNumber == 1)
        {
            Name = "Mineral Dragon";
            Force = mon.Force + aqua.Force + MBForce;
            Vitality = mon.Vitality + aqua.Vitality + MBVitality;
            Agility = mon.Agility + aqua.Agility + MBAgility;
            Fortiude = mon.Fortiude + aqua.Fortitude + MBFortitude;
            Intellect = mon.Intellect + aqua.Intellect + MBIntellect;
            Rationale = mon.Rationale + aqua.Rational + MBRational;
            Charisma = mon.Charisma + aqua.Charisma + MBCharima;
        }
        if (SignNumber == 2)
        {
            Name = "Mineral Dragon";
            Force = mon.Force + arie.Force + MBForce;
            Vitality = mon.Vitality + arie.Vitality + MBVitality;
            Agility = mon.Agility + arie.Agility + MBAgility;
            Fortiude = mon.Fortiude + arie.Fortitude + MBFortitude;
            Intellect = mon.Intellect + arie.Intellect + MBIntellect;
            Rationale = mon.Rationale + arie.Rational + MBRational;
            Charisma = mon.Charisma + arie.Charisma + MBCharima;
        }
        if (SignNumber == 3)
        {
            Name = "Mineral Dragon";
            Force = mon.Force + can.Force + MBForce;
            Vitality = mon.Vitality + can.Vitality + MBVitality;
            Agility = mon.Agility + can.Agility + MBAgility;
            Fortiude = mon.Fortiude + can.Fortitude + MBFortitude;
            Intellect = mon.Intellect + can.Intellect + MBIntellect;
            Rationale = mon.Rationale + can.Rational + MBRational;
            Charisma = mon.Charisma + can.Charisma + MBCharima;
        }
        if (SignNumber == 4)
        {
            Name = "Mineral Dragon";
            Force = mon.Force + cap.Force + MBForce;
            Vitality = mon.Vitality + cap.Vitality + MBVitality;
            Agility = mon.Agility + cap.Agility + MBAgility;
            Fortiude = mon.Fortiude + cap.Fortitude + MBFortitude;
            Intellect = mon.Intellect + cap.Intellect + MBIntellect;
            Rationale = mon.Rationale + cap.Rational + MBRational;
            Charisma = mon.Charisma + cap.Charisma + MBCharima;
        }
        if (SignNumber == 5)
        {
            Name = "Mineral Dragon";
            Force = mon.Force + gem.Force + MBForce;
            Vitality = mon.Vitality + gem.Vitality + MBVitality;
            Agility = mon.Agility + gem.Agility + MBAgility;
            Fortiude = mon.Fortiude + gem.Fortitude + MBFortitude;
            Intellect = mon.Intellect + gem.Intellect + MBIntellect;
            Rationale = mon.Rationale + gem.Rational + MBRational;
            Charisma = mon.Charisma + gem.Charisma + MBCharima;
        }
        if (SignNumber == 6)
        {
            Name = "Mineral Dragon";
            Force = mon.Force + leo.Force + MBForce;
            Vitality = mon.Vitality + leo.Vitality + MBVitality;
            Agility = mon.Agility + leo.Agility + MBAgility;
            Fortiude = mon.Fortiude + leo.Fortitude + MBFortitude;
            Intellect = mon.Intellect + leo.Intellect + MBIntellect;
            Rationale = mon.Rationale + leo.Rational + MBRational;
            Charisma = mon.Charisma + leo.Charisma + MBCharima;
        }
        if (SignNumber == 7)
        {
            Name = "Mineral Dragon";
            Force = mon.Force + lib.Force + MBForce;
            Vitality = mon.Vitality + lib.Vitality + MBVitality;
            Agility = mon.Agility + lib.Agility + MBAgility;
            Fortiude = mon.Fortiude + lib.Fortitude + MBFortitude;
            Intellect = mon.Intellect + lib.Intellect + MBIntellect;
            Rationale = mon.Rationale + lib.Rational + MBRational;
            Charisma = mon.Charisma + lib.Charisma + MBCharima;
        }
        if (SignNumber == 8)
        {
            Name = "Mineral Dragon";
            Force = mon.Force + pisc.Force + MBForce;
            Vitality = mon.Vitality + pisc.Vitality + MBVitality;
            Agility = mon.Agility + pisc.Agility + MBAgility;
            Fortiude = mon.Fortiude + pisc.Fortitude + MBFortitude;
            Intellect = mon.Intellect + pisc.Intellect + MBIntellect;
            Rationale = mon.Rationale + pisc.Rational + MBRational;
            Charisma = mon.Charisma + pisc.Charisma + MBCharima;
        }
        if (SignNumber == 9)
        {
            Name = "Mineral Dragon";
            Force = mon.Force + sagi.Force + MBForce;
            Vitality = mon.Vitality + sagi.Vitality + MBVitality;
            Agility = mon.Agility + sagi.Agility + MBAgility;
            Fortiude = mon.Fortiude + sagi.Fortitude + MBFortitude;
            Intellect = mon.Intellect + sagi.Intellect + MBIntellect;
            Rationale = mon.Rationale + sagi.Rational + MBRational;
            Charisma = mon.Charisma + sagi.Charisma + MBCharima;
        }
        if (SignNumber == 10)
        {
            Name = "Mineral Dragon";
            Force = mon.Force + scrop.Force + MBForce;
            Vitality = mon.Vitality + scrop.Vitality + MBVitality;
            Agility = mon.Agility + scrop.Agility + MBAgility;
            Fortiude = mon.Fortiude + scrop.Fortitude + MBFortitude;
            Intellect = mon.Intellect + scrop.Intellect + MBIntellect;
            Rationale = mon.Rationale + scrop.Rational + MBRational;
            Charisma = mon.Charisma + scrop.Charisma + MBCharima;
        }
        if (SignNumber == 11)
        {
            Name = "Mineral Dragon";
            Force = mon.Force + serp.Force + MBForce;
            Vitality = mon.Vitality + serp.Vitality + MBVitality;
            Agility = mon.Agility + serp.Agility + MBAgility;
            Fortiude = mon.Fortiude + serp.Fortitude + MBFortitude;
            Intellect = mon.Intellect + serp.Intellect + MBIntellect;
            Rationale = mon.Rationale + serp.Rational + MBRational;
            Charisma = mon.Charisma + serp.Charisma + MBCharima;
        }
        if (SignNumber == 12)
        {
            Name = "Mineral Dragon";
            Force = mon.Force + taur.Force + MBForce;
            Vitality = mon.Vitality + taur.Vitality + MBVitality;
            Agility = mon.Agility + taur.Agility + MBAgility;
            Fortiude = mon.Fortiude + taur.Fortitude + MBFortitude;
            Intellect = mon.Intellect + taur.Intellect + MBIntellect;
            Rationale = mon.Rationale + taur.Rational + MBRational;
            Charisma = mon.Charisma + taur.Charisma + MBCharima;
        }
        if (SignNumber == 13)
        {
            Name = "Mineral Dragon";
            Force = mon.Force + virg.Force + MBForce;
            Vitality = mon.Vitality + virg.Vitality + MBVitality;
            Agility = mon.Agility + virg.Agility + MBAgility;
            Fortiude = mon.Fortiude + virg.Fortitude + MBFortitude;
            Intellect = mon.Intellect + virg.Intellect + MBIntellect;
            Rationale = mon.Rationale + virg.Rationale + MBRational;
            Charisma = mon.Charisma + virg.Charisma + MBCharima;
        }

        HealthPoints = (Vitality + Fortiude) / 2;
        AbilityPoints = (Force + Intellect) / 2;
        Defence = Vitality;
        AttackDamage = Force;
        AttackSpeed = Agility;
        MagicDefence = Rationale;

        AttackBar = 0 / 100;

        //HPthing
        MaximumHealthPoints = HealthPoints;
        HealthPoints = MaximumHealthPoints;
        //clamps it
        HealthPoints = Mathf.Clamp(HealthPoints, 0, MaximumHealthPoints);


        // AP bar increasre by timesing agility by time.deltatime
        // divide delta time * agility by 32 
    }

    public MineralDragon()
    {

    }
}
