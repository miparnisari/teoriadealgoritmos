using System.ComponentModel.Design.Serialization;
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
        public void ShouldList11Influences_With11NodesInGraph()
        {
            // arrange
            var builder = new GraphBuilder(new GraphReader.GraphReader(@"Input" + System.IO.Path.DirectorySeparatorChar + "test.txt"));
            var graph = builder.Build();

            // act
            var influences = graph.GetInfluences().OrderByDescending().ToList();

            // assert
            string[] expectedInfluencesNames =
            {
                "Juana", "Roberto", "Carlos", "Esteban", "Milena", "Monica", "Pablo", "Lorena", "Tomas", "Brenda", "Nora"
            };

            Assert.AreEqual(expectedInfluencesNames, influences.Select(i => i.Node.Data.Name));
        }
    }
}
