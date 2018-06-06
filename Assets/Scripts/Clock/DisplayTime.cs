using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DisplayTime {
	#region Variables
	Text clockText, dayText, monthText, yearText;
	static DisplayTime instance = null;
	#endregion

	public static DisplayTime GetInstance() {
		if (instance == null) {
			instance = new DisplayTime ();
			instance.Initialize ();
		}

		return instance;
	}

	// Use this for initialization
	void Initialize () {	
		clockText = GameObject.Find ("Clock").GetComponent<Text>();
		dayText = GameObject.Find ("Day").GetComponent<Text>();
		monthText = GameObject.Find ("Month").GetComponent<Text>();
		yearText = GameObject.Find ("Year").GetComponent<Text>();
	}

	public void UpdateClockText(double minute, double hour, double day, double month, double year){
		dayText.text = "Day: " + day;
		clockText.text = "Time: " + hour + ":" + minute;
		monthText.text = "Month: " + month;
		yearText.text = "Year: " + year;
	}
}
