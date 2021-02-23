using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binx : Ally {

    Capricorn cap;
    ShapeshifterStats shapeshifter;

    public CharacterStats myStats;

    public int CBForce = 18;
    public int CBVitality = 30;
    public int CBAgility = 22;
    public int CBFortitude = 30;
    public int CBIntellect = 29;
    public int CBRational = 26;
    public int CBCharima = 18;

    int count;

    private void Start()
    {
        cap = new Capricorn();
        shapeshifter = new ShapeshifterStats();

        myStats = new CharacterStats();
        myStats.Name = "Binx";
        myStats.Force = shapeshifter.Force + cap.Force + CBForce;
        myStats.Vitality = shapeshifter.Vitality + cap.Vitality + CBVitality;
        myStats.Agility = shapeshifter.Agility + cap.Agility + CBAgility;
        myStats.Fortiude = shapeshifter.Fortiude + cap.Fortitude + CBFortitude;
        myStats.Intellect = shapeshifter.Intellect + cap.Intellect + CBIntellect;
        myStats.Rationale = shapeshifter.Rationale + cap.Rational + CBRational;
        myStats.Charisma = shapeshifter.Charisma + cap.Charisma + CBCharima;
        myStats.MaximumHealthPoints = (myStats.Vitality + myStats.Fortiude) / 2;
        myStats.HealthPoints = myStats.MaximumHealthPoints;
        myStats.AbilityPoints = (myStats.Force + myStats.Intellect) / 2;
        myStats.MoralPoints = 100;
        myStats.TravelStamina = (myStats.Vitality / 2) + ((myStats.Fortiude / 4) / myStats.Rationale);
        myStats.Defence = myStats.Vitality;
        myStats.AttackDamage = myStats.Force;
        myStats.AttackSpeed = myStats.Agility;
        myStats.MagicDefence = myStats.Rationale;


        myStats.HealthPoints = myStats.MaximumHealthPoints;
        //clamps it
        myStats.HealthPoints = Mathf.Clamp(myStats.HealthPoints, 0, myStats.MaximumHealthPoints);

        // AP bar increasre by timesing agility by time.deltatime
        // divide delta time * agility by 32 
    }
    void Update()
    {
        if (count == 0)
        {
            myStats.TotalAgility= cap.Agility + CBAgility;
            print("binx speed" + myStats.TotalAgility);

            count++;
        }
        else if (count == 1)
            return;
    }
}
