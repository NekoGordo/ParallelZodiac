using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SageStat : BaseStat {

	public void Sage(){
		ClassName = "Sage";
		Force = 6;
		Vitality = 16;
		Agility = 12;
		Fortiude = 17;
		Intellect = 32;
		Rationale = 31;
		Charisma = 24;
	}
    public SageStat () {
        Sage ();
    }
}
