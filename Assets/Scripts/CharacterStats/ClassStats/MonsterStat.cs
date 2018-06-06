using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : BaseStat {

	public void Monster(){//non human
		ClassName = "Monster";
		Force = 32;
		Vitality = 32;
		Agility = 32;
		Fortiude = 32;
		Intellect = 32;
		Rationale = 32;
		Charisma = 32;
	}
    public MonsterStat () {
        Monster ();
    }
}
