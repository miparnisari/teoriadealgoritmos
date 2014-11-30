namespace TP2.Test
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using TP2.CityProfile;

    [TestFixture()]
    public class CityProfileTest
    {
        [Test()]
        public void ShouldBuildCorrectProfile()
        {
            // arrange
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
            var actualProfile = profileCityCalculator.GetProfile(buildings);

            // assert
            var expectedProfile = new List<int>
            {
                0, 4, 1, 7, 4, 6, 6, 10, 9, 11, 11, 8, 12
            };

            Assert.AreEqual(expectedProfile, actualProfile);
        }
    }
}

