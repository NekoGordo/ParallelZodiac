using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taurus :  BaseTaurus {

     public void TaurusStat () {
        low = Random.Range ( 1, 13 );
        medium = Random.Range ( 13, 25 );
        high = Random.Range ( 25, 33 );
    }



    public Taurus () {
        TaurusStat ();

        StarSign = "Taurus";
        Force = high;
        Fortitude = high;
        Agility = low;
        Vitality = medium;
        Intellect = low;
        Rational = medium;
        Charisma = high;
       
       
    }
}
