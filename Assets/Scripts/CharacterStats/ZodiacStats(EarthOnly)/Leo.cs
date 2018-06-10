using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leo : BaseLeo {

    public void LeoStats () {
        low = Random.Range ( 1, 13 );
        medium = Random.Range ( 13, 25 );
        high = Random.Range ( 25, 33 );
    }



    public Leo () {
        LeoStats ();

        StarSign = "Leo";
        Force = high;
        Fortitude = medium;
        Agility = medium;
        Vitality = low;
        Intellect = medium;
        Rational = low;
        Charisma = high;
       
    }
}
