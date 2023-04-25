using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BardStat : BaseStat {

	public void Bard(){
		ClassName = "Bard";
		Force = 12;
		Vitality = 11;
		Agility = 13;
		Fortiude = 18;
		Intellect = 24;
		Rationale = 26;
		Charisma = 27;
	}
    public BardStat () {
        Bard ();
    }
}
