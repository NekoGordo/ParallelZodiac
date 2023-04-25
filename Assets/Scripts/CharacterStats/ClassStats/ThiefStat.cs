using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefStat : BaseStat {

	public void Thief(){
		ClassName = "Thief";
		Force = 5;
		Vitality = 14;
		Agility = 30;
		Fortiude = 28;
		Intellect = 26;
		Rationale = 18;
		Charisma = 8;
	}
    public ThiefStat () {
        Thief ();
    }
}
