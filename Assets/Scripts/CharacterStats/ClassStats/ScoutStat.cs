using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutStat : BaseStat {

	public void Scout(){
		ClassName = "Scout";
		Force = 18;
		Vitality = 18;
		Agility = 18;
		Fortiude = 18;
		Intellect = 18;
		Rationale = 18;
		Charisma = 18;
	}
    public ScoutStat () {
        Scout ();
    }
}
