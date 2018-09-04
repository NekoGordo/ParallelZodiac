using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zodiac
{
    private const int LOWEST = 1,
                      LOW_MID = 13,
                      HIGH_MID = 25,
                      HIGHEST = 33;

    protected int low, medium, high;

    public string StarSign { get; set; }
    public int Force { get; set; }
    public int Fortitude { get; set; }
    public int Agility { get; set; }
    public int Vitality { get; set;}
    public int Intellect { get; set; }
    public int Rational { get; set; }
    public int Charisma { get; set; }

    public void GenerateStat()
    {
        low = Random.Range(LOWEST, LOW_MID);
        medium = Random.Range(LOW_MID, HIGH_MID);
        high = Random.Range(HIGH_MID, HIGHEST);
    }
}
