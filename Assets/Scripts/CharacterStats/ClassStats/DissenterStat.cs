using System.Collections.Generic;
using UnityEngine;

public class DissenterStat : BaseStat {
	
	public void Dissenter(){
		ClassName = "Dissenter";
		Force = 20;
		Vitality = 20;
		Agility = 20;
		Fortiude = 20;
		Intellect = 20;
		Rationale = 32;
		Charisma = 20;
	}
    public DissenterStat () {
        Dissenter ();
    }
}
