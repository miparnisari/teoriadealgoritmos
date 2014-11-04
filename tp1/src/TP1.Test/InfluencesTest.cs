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
        public void ShouldList109Influences_With109nodesInGraph()
        {
            // arrange
            var builder = new GraphBuilder(new GraphReader.GraphReader(@"Input\realdata-small.txt"));
            var graph = builder.Build();

            // act
            var influences = graph.GetInfluences().OrderByDescending();

            // assert
            Assert.AreEqual(109, influences.Count());
        }

        [Test()]
        public void ShouldList3Influences_With3NodesInGraph()
        {
            // arrange
            const string text = @"nodedef>name VARCHAR,label VARCHAR,sex VARCHAR,locale VARCHAR,agerank INT
                                1,Milena,female,es_LA,11
                                2,Monica,female,es_LA,10
                                11,Roberto,male,es_LA,1
                                edgedef>node1 VARCHAR,node2 VARCHAR
                                1,11
                                2,11";
            /*
             *    1
             *   /
             * 11 ------ 2
             * 
             */
            var builder = new GraphBuilder(new StringGraphReader(text));
            var graph = builder.Build();

            // act
            var influences = graph.GetInfluences().OrderByDescending().ToList();

            double[] expectedInfluencesValues =
            {
                1/3.0, 0, 0
            };

            Assert.AreEqual(expectedInfluencesValues, influences.Select(i => i.Value));

            var names = influences.Select(i => i.Node.Data.Name).ToList();
            Assert.AreEqual("Roberto", names[0]); // 11
            Assert.AreEqual("Milena", names[1]);  // 1
            Assert.AreEqual("Monica", names[2]); // 2
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
            //string[] expectedInfluencesNames =
            //{
            //    "Juana", "Roberto", "Carlos", "Esteban", "Milena", "Monica", "Pablo", "Lorena", "Tomas", "Brenda", "Nora"
            //};

            const double d = 132;

            double[] expectedInfluencesValues =
            {
                38/d, 38/d, 22/d, 16/d, 10/d, 10/d, 4/d, 0, 0, 0, 0
            };

            Assert.AreEqual(expectedInfluencesValues, influences.Select(i => i.Value));

            var names = influences.Select(i => i.Node.Data.Name).ToList();
            Assert.IsTrue(names[0] == "Juana" || names[0] == "Roberto");
            Assert.IsTrue(names[1] == "Juana" || names[1] == "Roberto");
            Assert.AreEqual("Carlos", names[2]);
            Assert.AreEqual("Esteban", names[3]);
            Assert.IsTrue(names[4] == "Milena" || names[4] == "Monica");
            Assert.IsTrue(names[5] == "Milena" || names[5] == "Roberto");
            Assert.AreEqual("Pablo", names[6]);


        }
    }
}
