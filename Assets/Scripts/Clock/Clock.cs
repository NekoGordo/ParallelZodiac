using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Clock {
	//delegate void MultiDel();
	//MultiDel multiDel;
	//multiDel += FuncOne;
	//multiDel += funcTwo;
	//multiDel()
	//This calls both FuncOne and FuncTwo
	//multiDel -= FuncOne	//This removes functionality

	public delegate void FunctionToCall(double a, double b, double c, double d, double e);
	FunctionToCall functionToCall;

	string id;
	List<string> months;
	double minute, hour, day, second, month, year;
	double maxSeconds, maxMinutes, maxHours, maxDays, maxMonths;
	int timeScale;
	bool isPaused, currentPlanet; //, travelBetweenPlanets, isTravelling;

	// Use this for initialization
	public void Start () {
		
	}

	public void SetParams(string aID, double aMaxSecs, double aMaxMins, double aMaxHours, double aMaxDays, double aMaxMonths, List<string> aMonths, FunctionToCall aFunc, int aTimescale) {
		id = aID;

		maxSeconds = aMaxSecs;
		maxMinutes = aMaxMins;
		maxHours = aMaxHours;
		maxDays = aMaxDays;
		maxMonths = aMaxMonths;

		months = aMonths;

		timeScale = aTimescale;

		functionToCall = aFunc;

		month = 1;
		hour = 39;
		minute = 0;
		day = 40;
		year = 0001;

		isPaused = true;

		Debug.Log ("Params Set");
	}

	public void ClockUpdate (float aDeltaTime) {
		if (isPaused)
			return;

		Debug.Log (id);

		second += aDeltaTime * timeScale;

		if (second > maxSeconds) {
			minute++;
			second = 0;
		}
		if (minute >= maxMinutes) {
			hour++;
			minute = 0;
		}
		if (hour >= maxHours) {
			day++;
			hour = 0;
		}
		if (day >= maxDays) {
			day = 1;
			month++;
		} 
		if (month >= maxMonths) {
			month = 1;
			year++;
		}

		if(currentPlanet) 
			functionToCall (minute, hour, day, month, year);
	}

	void DoNothingFunc() {
		//In case you need the clock to do nothing when it updates
	}

	void TimeSkip(double aSeconds = 0, double aMinutes = 0, double aHours = 0, double aDays = 0, double aMonths = 0, double aYears = 0){
		minute += RollOver(second, aSeconds, maxSeconds);
		hour += RollOver (minute, aMinutes, maxMinutes);
		day += RollOver (hour, aHours, maxHours);
		month += RollOver (day, aDays, maxDays);
		year += RollOver (month, aMonths, maxMonths);

		second += aSeconds - (maxSeconds * RollOver (second, aSeconds, maxSeconds));
		minute += aMinutes - (maxMinutes * RollOver (minute, aMinutes, maxMinutes));
		hour += aHours - (maxHours * RollOver (hour, aHours, maxHours));
		day += aDays - (maxDays * RollOver (day, aDays, maxDays));
		month += aMonths - (maxMonths * RollOver (month, aMonths, maxMonths));
		year += aYears;
	}

	double RollOver(double valueA, double valueB, double max) {
		return (valueA + valueB) % max;
	}

	public string GetID() {
		return id;
	}
	public void SetID(string aID) {
		id = aID;
	}

	public void SetCurrentPlanet(bool curPlanet){
		currentPlanet = curPlanet;
	}

	public void Pause() {
		isPaused = true;
	}
	public void UnPause() {
		isPaused = false;
	}

	public double GetSecond() {
		return second;
	}
	public double GetMinute() {
		return minute;
	}
	public double GetHour() {
		return hour;
	}
	public double GetDay() {
		return day;
	}
	public string GetMonthAsString() {
		return months [(int)month];
	}
	public double GetYear() {
		return year;
	}

	//TODO: SetNewTime 
	//TODO: SetNewFunctionToCall
	//TODO: SetNewID
	//TODO: Test pause, stop, and cancel from monobehaviour
	//TODO: If they work, remove the isRunning var
}
