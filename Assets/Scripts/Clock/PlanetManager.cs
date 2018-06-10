using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class PlanetManager : MonoBehaviour {
	
	Dictionary<string, Planet> planetList;
	static string imn = "imn";
	static string zieal = "zieal";

	// Use this for initialization
	void Start () {
		planetList = new Dictionary<string, Planet> ();
		planetList.Add (imn, new Planet ());
		planetList.Add (zieal, new Planet ());

		SetUpClockForPlanet (imn);
		SetUpClockForPlanet (zieal);
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Planet planet in planetList.Values) {
			planet.PlanetClock.ClockUpdate (Time.deltaTime);
		}
	}

	void SetUpClockForPlanet(string planetName) {
		Planet planet = null;
		Clock clock = new Clock ();

		try{
			planetList.TryGetValue (planetName, out planet);

			if(planetName == imn) {
				clock.SetParams (planetName + "Clock", 
					StaticPlanetData.imn.maxSeconds,
					StaticPlanetData.imn.maxMinutes,
					StaticPlanetData.imn.maxHours,
					StaticPlanetData.imn.maxDays,
					StaticPlanetData.imn.maxMonths,
					StaticPlanetData.imn.months,
					DisplayTime.GetInstance ().UpdateClockText,
					StaticPlanetData.imn.timeScale);

				clock.SetCurrentPlanet(true);
			}
			else if(planetName == zieal) {
				clock.SetParams (planetName + "Clock", 
					StaticPlanetData.zieal.maxSeconds,
					StaticPlanetData.zieal.maxMinutes,
					StaticPlanetData.zieal.maxHours,
					StaticPlanetData.zieal.maxDays,
					StaticPlanetData.zieal.maxMonths,
					StaticPlanetData.zieal.months,
					DisplayTime.GetInstance ().UpdateClockText,
					StaticPlanetData.zieal.timeScale);

				clock.SetCurrentPlanet(true);
			}
			/*clock.SetParams (planetName + "Clock", 
					(double)StaticPlanetData.ReflectPropValue(planetName + "MaxSeconds"),
					(double)StaticPlanetData.ReflectPropValue(planetName + "MaxMinutes"),
					(double)StaticPlanetData.ReflectPropValue(planetName + "MaxHours"),
					(double)StaticPlanetData.ReflectPropValue(planetName + "MaxDays"),
					(double)StaticPlanetData.ReflectPropValue(planetName + "MaxMonths"),
					(List<string>)StaticPlanetData.ReflectPropValue(planetName + "Months"),
					DisplayTime.GetInstance ().UpdateClockText,
					(int)StaticPlanetData.ReflectPropValue(planetName + "TimeScale"));
			*/
			clock.UnPause ();

			planet.PlanetClock = clock;
		}
		catch (Exception ex) {
			Debug.Log (ex);
			//TODO: Throw an exception or something 
		}
	}

	public class Planet {
		public Clock PlanetClock { get; set; }
	}
}
