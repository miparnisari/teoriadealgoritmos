using System;
using System.Linq;
using TP1.GraphReader;
using NUnit.Framework;
using TP1.Influences;

namespace TP1.Test
{
    [TestFixture()]
    public class InfluencesTest
    {
        [Test()]
        public void ShouldList231Influences_With231nodesInGraph()
        {
            // arrange
            var builder = new GraphBuilder(new GraphReader.GraphReader(@"Input\realdata.txt"));
            var graph = builder.Build();

            // act
            var influences = graph.GetInfluences().OrderByDescending();

            // assert
            Assert.AreEqual(231, influences.Count());
        }

        [Test()]
        public void ShouldList11Influences_With11NodesInGraph()
        {
            // arrange
            var builder = new GraphBuilder(new GraphReader.GraphReader(@"Input\test.txt"));
            var graph = builder.Build();

            // act
            var influences = graph.GetInfluences().OrderByDescending().ToList();

            // assert
            string[] expectedInfluencesNames =
            {
                "Juana", "Roberto", "Carlos", "Esteban", "Milena", "Monica", "Pablo", "Lorena", "Tomas", "Brenda", "Nora"
            };

            const double d = 132;

            double[] expectedInfluencesValues =
            {
                38/d, 38/d, 22/d, 16/d, 10/d, 10/d, 4/d, 0, 0, 0, 0
            };

            Assert.AreEqual(expectedInfluencesNames, influences.Select(i => i.Node.Data.Name));
            Assert.AreEqual(expectedInfluencesValues, influences.Select(i => i.Value));
        }
    }
}
