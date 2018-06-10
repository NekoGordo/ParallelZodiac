using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binx : Ally {

    Capricorn cap;
    ShapeshifterStats shapeshifter;

    public int CBForce = 18;
    public int CBVitality = 30;
    public int CBAgility = 22;
    public int CBFortitude = 30;
    public int CBIntellect = 29;
    public int CBRational = 26;
    public int CBCharima = 18;

    private void Awake()
    {
        BasicType = "Ally";
        cap = new Capricorn();
        shapeshifter = new ShapeshifterStats();
        Name = "Binx";
        Force = shapeshifter.Force + cap.Force + CBForce;
        Vitality = shapeshifter.Vitality + cap.Vitality + CBVitality;
        Agility = shapeshifter.Agility + cap.Agility + CBAgility;
        Fortiude = shapeshifter.Fortiude + cap.Fortitude + CBFortitude;
        Intellect = shapeshifter.Intellect + cap.Intellect + CBIntellect;
        Rationale = shapeshifter.Rationale + cap.Rational + CBRational;
        Charisma = shapeshifter.Charisma + cap.Charisma + CBCharima;
        MaximumHealthPoints = (Vitality + Fortiude) / 2;
        HealthPoints = MaximumHealthPoints;
        AbilityPoints = (Force + Intellect) / 2;
        MoralPoints = 100;
        TravelStamina = (Vitality / 2) + ((Fortiude / 4) / Rationale);
        Defence = Vitality;
        AttackDamage = Force;
        AttackSpeed = Agility;
        MagicDefence = Rationale;

        AttackBar = 0 / 100;

        HealthPoints = MaximumHealthPoints;
        //clamps it
        HealthPoints = Mathf.Clamp(HealthPoints, 0, MaximumHealthPoints);

        // AP bar increasre by timesing agility by time.deltatime
        // divide delta time * agility by 32 
    }

    public Binx()
    {
        
    }
}
