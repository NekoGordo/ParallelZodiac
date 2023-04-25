using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat {

	public string ClassName { get; set; }// players Class

	public int Force { get; set; } //melee damage and part of magic damage (has OW effects but implement later)
	public int Vitality { get; set; } //part of HP offers Defence
	public int Agility { get; set; } // speed (determins attack order in TB mode and your movementspeed(how far you can go))
	public int Fortiude { get; set; } // other part of HP (has other effects for later)
	public int Intellect { get; set; } // part of magic damage (has OW effects but implemented later)
	public int Rationale { get; set; } // magical defence and is used in stamina combined with half Vitality and quater Fortiude / Rationale
	public int Charisma { get; set; } // has effects on spells and OW effects

}
