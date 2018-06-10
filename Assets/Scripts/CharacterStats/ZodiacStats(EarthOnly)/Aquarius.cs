using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aquarius : BaseAquarius {

    private void AquariusStats () {
        low = Random.Range ( 1, 13 );
        medium = Random.Range ( 13, 25 );
        high = Random.Range ( 25, 33 );
    }



    public Aquarius() {
        AquariusStats ();
    
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
