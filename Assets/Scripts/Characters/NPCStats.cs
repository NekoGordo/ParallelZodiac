using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStats {
    public int rand;
    private void Stat () {
        rand = Random.Range ( 1, 33 );
    }

    public string Name { get; set; }

    private int force = 0;
    public int Force { get { Stat (); return rand; } set { force = value; } }

    private int fortitude = 0;
    public int Fortitude { get { Stat (); return rand; } set { fortitude = value; } }

    private int agility = 0;
    public int Agility { get { Stat (); return rand; } set { agility = value; } }

    private int vitality = 0;
    public int Vitality { get { Stat (); return rand; } set { vitality = value; } }

    private int intellect = 0;
    public int Intellect { get { Stat (); return rand; } set { intellect = value; } }

    private int rational = 0;
    public int Rationale { get { Stat (); return rand; } set { rational = value; } }

    private int charisma = 0;
    public int Charisma { get { Stat (); return rand; } set { charisma = value; } }

}
