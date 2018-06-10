using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarksmanStat : BaseStat {
	
	public void Marksman(){
		ClassName = "Marksman";
		Force = 24;
		Vitality = 13;
		Agility = 28;
		Fortiude = 26;
		Intellect = 16;
		Rationale = 19;
		Charisma = 30;
	}
    public MarksmanStat () {
        Marksman ();
    }
}
