using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gemini : BaseGemini {

    public void GeminiStats () {
        low = Random.Range ( 1, 13 );
        medium = Random.Range ( 13, 25 );
        high = Random.Range ( 25, 33 );
    }



    public Gemini () {
        GeminiStats ();

        StarSign = "Gemini";
        Force = low;
        Fortitude = low;
        Agility = high;
        Vitality = medium;
        Intellect = high;
        Rational = low;
        Charisma = medium;
       
    }
}
