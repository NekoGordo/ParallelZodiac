using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virgo : BaseVirgo {

    public void VirgoStats () {
        low = Random.Range ( 1, 13 );
        medium = Random.Range ( 13, 25 );
        high = Random.Range ( 25, 33 );
    }



    public Virgo () {
        VirgoStats ();

        StarSign = "Virgo";
        Force = medium;
        Fortitude = low;
        Agility = low;
        Vitality = high;
        Intellect = medium;
        Rationale = high;
        Charisma = low;
    }
}
