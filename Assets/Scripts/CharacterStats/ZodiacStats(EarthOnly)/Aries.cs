using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aries : BaseAries {


    public void AriesStat () {
         low = Random.Range ( 1, 13 );
         medium = Random.Range ( 13, 25 );
         high = Random.Range ( 25, 33 );
    }



    public Aries () {
        AriesStat ();

        StarSign = "Aries";
        Force = high;
        Fortitude = high;
        Agility = high;
        Vitality = low;
        Intellect = medium;
        Rational = low;
        Charisma = medium;
       
    }

}
