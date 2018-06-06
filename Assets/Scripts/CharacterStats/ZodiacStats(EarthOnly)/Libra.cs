using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Libra : BaseLibra {

    public void LibraStats () {
        low = Random.Range ( 1, 13 );
        medium = Random.Range ( 13, 25 );
        high = Random.Range ( 25, 33 );
    }



    public Libra () {
        LibraStats ();

        StarSign = "Libra";
        Force = medium;
        Fortitude = low;
        Agility = low;
        Vitality = medium;
        Intellect = high;
        Rational = low;
        Charisma = high;
        
    }
}
