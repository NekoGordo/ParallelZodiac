using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssassinStats : BaseStat {

	private void Assassin(){
		ClassName = "Assassin";
		Force = 9;
		Vitality = 26;
		Agility = 30;
		Fortiude = 18;
		Intellect = 31;
		Rationale = 13;
		Charisma = 8;
	}

    public AssassinStats () {
        Assassin ();
    }
}
