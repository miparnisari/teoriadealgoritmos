using System;
using System.Collections.Generic;
using System.IO;

namespace TP2.CityProfile
{
	public class BuildingsFileReader
	{
		public static List<Building> ReadFileContent(StreamReader file)
		{
			var buildings = new List<Building> ();
			while (!file.EndOfStream) 
			{
				var line = file.ReadLine ();
				var parts = line.Split (',');
				if (parts.Length == 3) {
					buildings.Add(new Building(Int32.Parse(parts[0]), Int32.Parse(parts[2]), Int32.Parse(parts[1])));
				}
			}
			return buildings;
		}
	}
}

