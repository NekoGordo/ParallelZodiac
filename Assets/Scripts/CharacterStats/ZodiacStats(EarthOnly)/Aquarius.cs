using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aquarius : Zodiac {
    public Aquarius()
    {
        GenerateStat();
    
        StarSign = "Aquarius";
        Force = low;
        Fortitude = medium;
        Agility = low;
        Vitality = high;
        Intellect = high;
        Rational = medium;
        Charisma = medium;
        
    }
}
