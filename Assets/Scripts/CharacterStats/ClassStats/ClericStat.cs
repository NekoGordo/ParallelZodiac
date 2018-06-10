using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClericStat : BaseStat {

	public void Cleric(){
		ClassName = "Cleric";
		Force = 20;
		Vitality = 20;
		Agility = 20;
		Fortiude = 20;
		Intellect = 20;
		Rationale = 20;
		Charisma = 32;
	}
    public ClericStat () {
        Cleric ();
    }
}
