using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pisces : BasePisces {

    public void PiscesStats () {
        low = Random.Range ( 1, 13 );
        medium = Random.Range ( 13, 25 );
        high = Random.Range ( 25, 33 );
    }



    public Pisces () {
        PiscesStats ();
        StarSign = "Pisces";
        Force = low;
        Fortitude = low;
        Agility = high;
        Vitality = low;
        Intellect = medium;
        Rational = medium;
        Charisma = high;
        
    }
}
