using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Karma : MonoBehaviour {

	public int goodKarma = 0;
	public int badKarma = 0;
	public int MaxgoodKArma = 100;
	public int MaxbadKArma = -100;
	public int MinKarma = 0;
	public Slider goodKarmabar;
	public Slider badKarmabar;

	// Use this for initialization
	void Start () {
		goodKarma = MinKarma;
		badKarma = MinKarma;
		goodKarmabar.value = KarmaGood();
		badKarmabar.value = KarmaBad();
	}
	
	// Update is called once per frame
	void Update () {
		if (goodKarma >= MaxgoodKArma)
			goodKarma = MaxgoodKArma;
		if (badKarma <= MaxbadKArma)
			badKarma = MaxbadKArma;
		if (goodKarma <= MinKarma)
			goodKarma = MinKarma;
		if (badKarma >= MinKarma)
			badKarma = MinKarma;

		goodKarmabar.value = KarmaGood();
		badKarmabar.value = KarmaBad();

		if (Input.GetKeyDown (KeyCode.K)) {
			if (badKarma == MinKarma) {
				goodKarma++;
			} else if (badKarma < MinKarma) {
				badKarma++;
			}
		} else if (Input.GetKeyDown (KeyCode.J)) {
			if (goodKarma == MinKarma) {
				badKarma--;
			}else if (goodKarma > MinKarma) {
				goodKarma--;
			}
		}
	}

	float KarmaGood(){
		return goodKarma / MaxgoodKArma;
	}
	float KarmaBad(){
		return badKarma / MaxbadKArma;

	}
}
