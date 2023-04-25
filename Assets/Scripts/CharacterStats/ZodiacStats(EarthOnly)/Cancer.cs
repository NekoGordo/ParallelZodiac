using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cancer : BaseCancer {

    public void CancerStats () {
        low = Random.Range ( 1, 13 );
        medium = Random.Range ( 13, 25 );
        high = Random.Range ( 25, 33 );
    }



    public Cancer () {
        CancerStats ();

        StarSign = "Cancer";
        Force = low;
        Fortitude = high;
        Agility = low;
        Vitality = medium;
        Intellect = high;
        Rational = medium;
        Charisma = high;
       
    }
}
