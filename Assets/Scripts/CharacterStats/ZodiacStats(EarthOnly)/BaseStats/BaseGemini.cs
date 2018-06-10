﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGemini {

    private string starsign = "";
    public string StarSign { get { return starsign; } set { starsign = value; } }

    public int low;
    public int medium;
    public int high;
    private void Stat () {
        low = Random.Range ( 1, 13 );
        medium = Random.Range ( 13, 25 );
        high = Random.Range ( 25, 33 );
    }

    private int force = 0;
    public int Force { get { Stat (); return low; } set { force = value; } }

    private int fortitude = 0;
    public int Fortitude { get { Stat (); return low; } set { fortitude = value; } }

    private int agility = 0;
    public int Agility { get { Stat (); return high; } set { agility = value; } }

    private int vitality = 0;
    public int Vitality { get { Stat (); return medium; } set { vitality = value; } }

    private int intellect = 0;
    public int Intellect { get { Stat (); return high; } set { intellect = value; } }

    private int ratoinal = 0;
    public int Rational { get { Stat (); return low; } set { ratoinal = value; } }

    private int charisma = 0;
    public int Charisma { get { Stat (); return medium; } set { charisma = value; } }

}
