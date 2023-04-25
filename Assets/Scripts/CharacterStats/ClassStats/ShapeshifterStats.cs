using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeshifterStats : BaseStat {

	public void Shapeshifter(){
		ClassName = "Shapehifter";
		Force = 17;
		Vitality = 17;
		Agility = 17;
		Fortiude = 17;
		Intellect = 17;
		Rationale = 17;
		Charisma = 17;
	}
    public ShapeshifterStats () {
        Shapeshifter ();
    }
}
