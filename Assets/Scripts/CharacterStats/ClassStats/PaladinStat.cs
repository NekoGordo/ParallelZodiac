using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinStat : BaseStat {

	public void Paladin(){
		ClassName = "Paladin";
		Force = 30;
		Vitality = 30;
		Agility = 32;
		Fortiude = 30;
		Intellect = 30;
		Rationale = 30;
		Charisma = 30;
	}
    public PaladinStat () {
        Paladin ();
    }
}
