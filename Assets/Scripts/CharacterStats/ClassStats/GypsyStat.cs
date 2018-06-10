using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GypsyStat : BaseStat{

	public void Gypsy(){
		ClassName = "Gypsy";
		Force = 15;
		Vitality = 13;
		Agility = 25;
		Fortiude = 27;
		Intellect = 30;
		Rationale = 23;
		Charisma = 31;
	}
    public GypsyStat () {
        Gypsy ();

    }
}
