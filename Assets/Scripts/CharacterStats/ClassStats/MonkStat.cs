using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkStat : BaseStat {

	public void Monk(){
		ClassName = "Monk";
		Force = 30;
		Vitality = 32;
		Agility = 31;
		Fortiude = 22;
		Intellect = 25;
		Rationale = 32;
		Charisma = 18;
	}
    public MonkStat () {
        Monk ();
    }
}
