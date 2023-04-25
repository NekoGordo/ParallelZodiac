using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerStat : BaseStat {

	public void Ranger(){
		ClassName = "Ranger";
		Force = 22;
		Vitality = 25;
		Agility = 25;
		Fortiude = 30;
		Intellect = 14;
		Rationale = 19;
		Charisma = 25;
	}
    public RangerStat () {
        Ranger ();
    
    }
}
