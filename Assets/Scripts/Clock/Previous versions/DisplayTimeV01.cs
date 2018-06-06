using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayTimeV01 : MonoBehaviour {
	//27 time scale = 1min 0 seconds and 21 milleseconds
	public const int TIMESCALE = 27;

	private Text clockText, dayText, monthText, yearText;

	public double minute, hour, day, seconds, month, year;

	public bool Paused;

	public bool IsOnImn, IsOnZieal, TravelBetweenPlanets;

	// Use this for initialization
	void Start () {
		IsOnImn = true;
		TravelBetweenPlanets = false;
		IsOnZieal = false;
		Paused = false;
		month = 1;
		hour = 39;
		minute = 0;
		day = 40;
		year = 0001;

		clockText = GameObject.Find ("Clock").GetComponent<Text>();
		dayText = GameObject.Find ("Day").GetComponent<Text>();
		monthText = GameObject.Find ("Month").GetComponent<Text>();
		yearText = GameObject.Find ("Year").GetComponent<Text>();

		//CalculateMonth ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			if (Paused == false) {
				Paused = true;
			} else if (Paused == true) {
				Paused = false;
			}
		}
		if (Paused == true) {
			return;
		} else if (Paused == false) {
			if (TravelBetweenPlanets == false) {
				CalculateTime ();
			} else if (Input.GetKeyDown (KeyCode.A)) {
				TravelBetweenPlanets = true;
			}
			if (TravelBetweenPlanets == true) {
				StartCoroutine (Travel ());
			}
			if (Input.GetKeyDown (KeyCode.T)) {
					if (IsOnImn == true) {
						IsOnImn = false;
						IsOnZieal = true;
					} else if (IsOnZieal == true) {
						IsOnZieal = false;
						IsOnImn = true;
					}
				}
			//	CalculateTime ();
			if (Input.GetKeyDown (KeyCode.A)) {
				Debug.Log ("A");
			}
		}
	}

	IEnumerator Travel(){
		yield return new WaitForSeconds (5f);
		TravelBetweenPlanets = false;
		Update ();

	}

	/// <summary>
	/// Calculates the time.
	/// </summary>
	void CalculateTime(){
		if (IsOnImn == true) {
			seconds += Time.deltaTime * TIMESCALE;
			//calculates the seconds
			if (seconds >= 40) {
				minute++;
				seconds = 0;
				TextCallFucntion ();
			} 
		//calculates the minuets
		else if (minute >= 40) {
				hour++;
				minute = 0;
				TextCallFucntion ();
			}
		//calculates hours
		else if (hour >= 40) {
				day++;
				hour = 0;
				TextCallFucntion ();
			}
		/**calculates month set the day to read 41 because it will 
		 * instently change appon reaching sent number*/
		else if (day >= 41) {
				CalculateMonth ();
			} 
		/**calculates year set the month to read 18 because it will 
		 * instently change appon reaching sent number*/
		else if (month >= 18) {
				month = 1;
				year++;
				TextCallFucntion ();
			}
		}
		if (IsOnZieal) {
			seconds += Time.deltaTime * TIMESCALE;
			//calculates the seconds
			if (seconds >= 40) {
				minute++;
				seconds = 0;
				TextCallFucntion ();
			} 
			//calculates the minuets
			else if (minute >= 40) {
				hour++;
				minute = 0;
				TextCallFucntion ();
			}
			//calculates hours
			else if (hour >= 40) {
				day++;
				hour = 0;
				TextCallFucntion ();
			}
			/**calculates month set the day to read 41 because it will 
		 * instently change appon reaching sent number*/
			else if (day >= 41) {
				CalculateMonth ();
			} 
			/**calculates year set the month to read 11 because it will 
		 * instently change appon reaching sent number*/
			else if (month >= 11) {
				month = 1;
				year++;
				TextCallFucntion ();
			}
		}
	}

	void CalculateMonth (){
		if (IsOnZieal == true) {
			if (month == 1)
				monthText.text = "Yenmish";
			else if (month == 2)
				monthText.text = "Drasish";
			else if (month == 3)
				monthText.text = "Mehnish";
			else if (month == 4)
				monthText.text = "Viilish";
			else if (month == 5)
				monthText.text = "Oshen";
			else if (month == 6)
				monthText.text = "Mishehn";
			else if (month == 7)
				monthText.text = "Kehtsehn";
			else if (month == 8)
				monthText.text = "Vutsehn";
			else if (month == 9)
				monthText.text = "Tiinfaht";
			else if (month == 10)
				monthText.text = "Uhlfaht";
			else if (month == 11)
				monthText.text = "Rahnfaht";
			else if (month == 12)
				monthText.text = "Zehnfaht";
			else if (month == 13)
				monthText.text = "Lukruht";
			else if (month == 14)
				monthText.text = "Jalruht";
			else if (month == 15)
				monthText.text = "Datruht";
			else if (month == 16)
				monthText.text = "Zinruht";
			else if (month == 17)
				monthText.text = "Mashdhen";
		}
		else if (IsOnZieal == true) {
			if (month == 1)
				monthText.text = "Jahmut";
			else if (month == 2)
				monthText.text = "Feckmut";
			else if (month == 3)
				monthText.text = "Duhnderr";
			else if (month == 4)
				monthText.text = "Thenderr";
			else if (month == 5)
				monthText.text = "Poshvickt";
			else if (month == 6)
				monthText.text = "Soltvickt";
			else if (month == 7)
				monthText.text = "Nishdackt";
			else if (month == 8)
				monthText.text = "Rrahkdackt";
			else if (month == 9)
				monthText.text = "Eilsindt";
			else if (month == 10)
				monthText.text = "Lealsindt";
		}
		month++;
		day = 1;
		Debug.Log (monthText.text);
		TextCallFucntion ();
	}

	void TextCallFucntion(){
		dayText.text = "Day: " + day;
		clockText.text = "Time: " + hour + ":" + minute;
		yearText.text = "Year: " + year;
		monthText.text = month.ToString ();
	}


}
