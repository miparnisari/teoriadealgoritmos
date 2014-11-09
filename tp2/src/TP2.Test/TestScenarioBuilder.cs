using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Framework;
using TP2.Model;

namespace TP2.Test
{
    [TestFixture()]
    public class TestScenarioBuilder
    {
        private Scenario scenario;

        [SetUp]
        public void SetUp()
        {
            var filepath = Path.Combine(Environment.CurrentDirectory, "Input", "Scenario1.txt");
            var builder = new ScenarioBuilder(new ScenarioFileReader(filepath));
            this.scenario = builder.Build();
        }

        [Test()]
        public void ShouldBuildTrains()
        {
            Assert.AreEqual(4, scenario.Trains.Count);
        }

        [Test()]
        public void ShouldBuildRequest()
        {
            Assert.AreEqual("Jujuy", scenario.Request.Origin.Name);
            Assert.AreEqual("Buenos Aires", scenario.Request.Destination.Name);
            Assert.AreEqual(8, scenario.Request.StartTime.Hour);
            Assert.AreEqual(0, scenario.Request.StartTime.Minute);
        }

        [Test()]
        public void ShouldBuildCities()
        {
            Assert.AreEqual(3, scenario.Cities.Count);
            Assert.IsTrue(scenario.Cities.Contains(new City("jujuy")));
            Assert.IsTrue(scenario.Cities.Contains(new City("tucuman")));
            Assert.IsTrue(scenario.Cities.Contains(new City("buenos aires")));
        }

        [Test()]
        public void ShouldBuildRoute()
        {
            var trainOne = scenario.Trains[0];

            Assert.AreEqual(1, trainOne.Routes.Count);

            Assert.AreEqual(9, trainOne.Routes.First().DepartTime.Hour);
            Assert.AreEqual(49, trainOne.Routes.First().DepartTime.Minute);
            Assert.AreEqual("Jujuy", trainOne.Routes.First().Origin.Name);

            Assert.AreEqual(10, trainOne.Routes.First().ArrivalTime.Hour);
            Assert.AreEqual(06, trainOne.Routes.First().ArrivalTime.Minute);
            Assert.AreEqual("Tucuman", trainOne.Routes.First().Destination.Name);
        }
    }
}
