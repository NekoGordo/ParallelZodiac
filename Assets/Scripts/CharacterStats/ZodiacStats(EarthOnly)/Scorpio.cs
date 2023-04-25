using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorpio : BaseScorpio {

    public void ScorpioStats () {
        low = Random.Range ( 1, 13 );
        medium = Random.Range ( 13, 25 );
        high = Random.Range ( 25, 33 );
    }



    public Scorpio () {
        ScorpioStats ();

        StarSign = "Scrpio";
        Force = high;
        Fortitude = low;
        Agility = low;
        Vitality = medium;
        Intellect = high;
        Rational = low;
        Charisma = medium;
       
    }
}
