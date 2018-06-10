using System.Collections.Generic;

public static class StaticPlanetData {

	public enum planets {
		Imn = 0,
		Zieal,

		Count	//This is used as a counter of sorts, to determine the number of items in the enum
	}

	public static object ReflectPropValue(string property) {
		return typeof(StaticPlanetData).GetProperty (property).GetValue (null, null);
		//PropertyInfo propInfo = typeof(StaticPlanetData).GetProperty(property);
		//return propInfo.GetValue (null, null);
	}

	public static class imn {
		public static List<string> months = new List<string> (){
			"Yenmish",
			"Drasish",
			"Mehnish",
			"Viilish",
			"Oshen",
			"Mishehn",
			"Kehtsehn",
			"Vutsehn",
			"Tiinfaht",
			"Uhlfaht",
			"Rahnfaht",
			"Zehnfaht",
			"Lukruht",
			"Jalruht",
			"Datruht",
			"Zinruht",
			"Mashdhen"
		};

		public static double maxSeconds = 40; 
		public static double maxMinutes = 40; 
		public static double maxHours = 40; 
		public static double maxDays = 41; 
		public static double maxMonths = months.Count;

		//27 time scale = 1min 0 seconds and 21 milleseconds
		public static int timeScale = 27;
	}

	public static class zieal {
		public static List<string> months = new List<string> (){
			"Jahmut",
			"Feckmut",
			"Duhnderr",
			"Thenderr",
			"Poshvickt",
			"Soltvickt",
			"Nishdackt",
			"Rrahkdackt",
			"Eilsindt",
			"Lealsindt"
		};

		public static double maxSeconds = 40; 
		public static double maxMinutes = 40; 
		public static double maxHours = 40; 
		public static double maxDays = 41; 
		public static double maxMonths = months.Count;

		//27 time scale = 1min 0 seconds and 21 milleseconds
		public static int timeScale = 27;
	}
}
