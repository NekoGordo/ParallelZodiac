using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sagittarius : BaseSagittarius {

    public void SagittariusStats () {
        low = Random.Range ( 1, 13 );
        medium = Random.Range ( 13, 25 );
        high = Random.Range ( 25, 33 );
    }



    public Sagittarius () {
        SagittariusStats ();

        StarSign = "Sagittarius";
        Force = medium;
        Fortitude = medium;
        Agility = medium;
        Vitality = low;
        Intellect = low;
        Rational = high;
        Charisma = high;
    }
}
