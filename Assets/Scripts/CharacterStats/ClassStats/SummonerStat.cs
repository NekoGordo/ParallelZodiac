using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerStat : BaseStat {

	public void Summoner(){
		ClassName = "Summoner";
		Force = 5;
		Vitality = 15;
		Agility = 4;
		Fortiude = 31;
		Intellect = 27;
		Rationale = 27;
		Charisma = 15;
	}
    public SummonerStat () {
        Summoner ();
    }
}
