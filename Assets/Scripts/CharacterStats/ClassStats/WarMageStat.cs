using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarMageStat : BaseStat {

	public void WarMage(){
		ClassName = "War-Mage";
		Force = 21;
		Vitality = 19;
		Agility = 9;
		Fortiude = 19;
		Intellect = 32;
		Rationale = 22;
		Charisma = 10;
	}
    public WarMageStat () {
        WarMage ();
    }
}
