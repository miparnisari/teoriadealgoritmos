using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TP2.CityProfile;

namespace TP2.Test
{
	[TestFixture()]
	public class CityProfileTest
	{
		[Test()]
		public void TestCase ()
		{
			// set up
			var buildings = new List<Building>
			{
				new Building(3, 8, 6),
				new Building(0, 5, 4),
				new Building(6, 10, 10),
				new Building(1, 4, 7),
				new Building(9, 11, 11),
				new Building(7, 12, 8)
			};
			var profileCityCalculator = new ProfileCityCalculator();

			// act
			var profile = profileCityCalculator.GetProfile(buildings);

			// Assert
			Assert.AreEqual(profile.ElementAt(0), 0);
			Assert.AreEqual(profile.ElementAt(1), 4);
			Assert.AreEqual(profile.ElementAt(2), 1);
			Assert.AreEqual(profile.ElementAt(3), 7);
			Assert.AreEqual(profile.ElementAt(4), 4);
			Assert.AreEqual(profile.ElementAt(5), 6);
			Assert.AreEqual(profile.ElementAt(6), 6);
			Assert.AreEqual(profile.ElementAt(7), 10);
			Assert.AreEqual(profile.ElementAt(8), 9);
			Assert.AreEqual(profile.ElementAt(9), 11);
			Assert.AreEqual(profile.ElementAt(10), 11);
			Assert.AreEqual(profile.ElementAt(11), 8);
			Assert.AreEqual(profile.ElementAt(12), 12);
		}
	}
}

