using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeomancerStat : BaseStat {

	public void Geomancer(){
		ClassName = "Geomancer";
		Force = 27;
		Vitality = 27;
		Agility = 11;
		Fortiude = 19;
		Intellect = 28;
		Rationale = 29;
		Charisma = 14;
	}
    public GeomancerStat () {
        Geomancer ();
    }
}
