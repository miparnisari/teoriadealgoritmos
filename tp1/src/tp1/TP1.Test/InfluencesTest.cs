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
        public void ShouldListInfluences_With250nodesInGraph()
        {
            try
            {
                // arrange
                var builder = new GraphBuilder(new GraphReader.GraphReader(@"Input\realdata.txt"));
                var graph = builder.Build();

                // act
                var influences = graph.GetInfluences().OrderByDescending().ToList();
            }
            catch (Exception e)
            {
                Assert.Fail("Exception thrown: " + e.Message);
            }
        }

        [Test()]
        public void ShouldListInfluences_With11Nodes()
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
