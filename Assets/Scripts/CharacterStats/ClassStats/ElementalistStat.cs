using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalistStat : BaseStat {

	public void Elementalist(){
		ClassName = "Elementalist";
		Force = 8;
		Vitality = 12;
		Agility = 9;
		Fortiude = 14;
		Intellect = 31;
		Rationale = 26;
		Charisma = 16;
	}
    public ElementalistStat () {
        Elementalist ();
    }
}
