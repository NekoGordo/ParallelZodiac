using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunmanStat : BaseStat {

	public void Gunman(){
		ClassName = "Gunman";
		Force = 16;
		Vitality = 8;
		Agility = 23;
		Fortiude = 22;
		Intellect = 28;
		Rationale = 16;
		Charisma = 21;
	}
    public GunmanStat () {
        Gunman ();
    }
}
