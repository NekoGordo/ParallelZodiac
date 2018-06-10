using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherStat : BaseStat{

	public void Archer(){
		ClassName = "Archer";
		Force = 15;
		Vitality = 18;
		Agility = 30;
		Fortiude = 16;
		Intellect = 20;
		Rationale = 25;
		Charisma = 15;
	}

    public ArcherStat () {
        Archer ();

    }
}
