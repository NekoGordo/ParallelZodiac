using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scraps : MonoBehaviour {
	BaseMeatItem meat;
	public string name = "";
	public int price;
	public string desc = "";
	public string rairty = "";
	// Use this for initialization
	void Start () {
	meat.MeatName = name;
	FlavourText = desc;
	ItemWorth = rairty;
	ItemPrice = price;
	}
	
}
