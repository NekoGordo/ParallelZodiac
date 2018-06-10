using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serpentarius : BaseSerpentarius {

    public void SerpentariusStats () {
        low = Random.Range ( 1, 13 );
        medium = Random.Range ( 13, 25 );
        high = Random.Range ( 25, 33 );
    }



    public Serpentarius () {
        SerpentariusStats ();

        StarSign = "Serpentarius";
        Force = medium;
        Fortitude = high;
        Agility = medium;
        Vitality = low;
        Intellect = high;
        Rational = high;
        Charisma = low;
        
    }
}
