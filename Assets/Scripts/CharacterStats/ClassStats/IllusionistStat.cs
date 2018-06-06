using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllusionistStat : BaseStat {

	public void Illusionist(){
		ClassName = "Illusionist";
		Force = 9;
		Vitality = 10;
		Agility = 15;
		Fortiude = 31;
		Intellect = 32;
		Rationale = 27;
		Charisma = 18;
	}
    public IllusionistStat () {
        Illusionist ();
    }
}
