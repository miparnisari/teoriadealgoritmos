using System;
using System.Linq;
using TP1.GraphReader;
using NUnit.Framework;
using tp1.Influences;

namespace TP1.Test
{
    [TestFixture()]
    public class InfluencesTest
    {
        [Test()]

        public void ShouldListInfluencesInCorrectOrder()
        {
            // arrange
            var builder = new GraphBuilder(new GraphReader.GraphReader(@"Input\test.txt"));
            var graph = builder.Build();

            // act
            var influences = graph.Influences().OrderByDescending(i => i.Item2).ToList();

            // assert
            string[] expectedInfluencesInOrder =
            {
                "Juana", "Roberto", "Carlos", "Esteban", "Milena",
                "Monica", "Pablo", "Lorena", "Tomas", "Brenda", "Nora"
            };

            Assert.AreEqual(expectedInfluencesInOrder.Count(), influences.Count());
            Assert.AreEqual(expectedInfluencesInOrder, influences.Select(i => i.Item1.Data.Name).ToArray());
        }
    }
}
