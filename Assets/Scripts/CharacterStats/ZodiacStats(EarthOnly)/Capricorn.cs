using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capricorn : BaseCapricorn {

    public void CapriconStats () {
        low = Random.Range ( 1, 13 );
        medium = Random.Range ( 13, 25 );
        high = Random.Range ( 25, 33 );
    }



    public Capricorn () {
        CapriconStats ();

        StarSign = "Capricorn";
        Force = medium;
        Fortitude = high;
        Agility = medium;
        Vitality = high;
        Intellect = high;
        Rational = low;
        Charisma = low;
       
    }
}
