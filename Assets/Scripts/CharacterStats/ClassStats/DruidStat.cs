using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruidStat : BaseStat {
	
	public void Druid(){
		ClassName = "Druid";
		Force = 25;
		Vitality = 25;
		Agility = 25;
		Fortiude = 32;
		Intellect = 25;
		Rationale = 25;
		Charisma = 25;
	}
    public DruidStat () {
        Druid ();
    }
}
