using System;
using System.Linq;
using NUnit.Framework;
using TP1.GraphReader;
using TP1.Recommendations;

namespace TP1.Test
{
    [TestFixture()]
    public class RecommendationsTest
    {
        [Test()]
        public void GraphWithTwoNodesShouldNotHaveRecommendations()
        {
            // arrange
            var fileContent =
                "nodedef>name VARCHAR,label VARCHAR,sex VARCHAR,locale VARCHAR,agerank INT" + Environment.NewLine +
                    "1,Juan,male,es_LA,2" + Environment.NewLine +
                    "2,Maria,female,es_LA,1" + Environment.NewLine +
                    "edgedef>node1 VARCHAR,node2 VARCHAR" + Environment.NewLine +
                    "1,2";

            // act
            var builder = new GraphBuilder(new StringGraphReader(fileContent));
            var graph = builder.Build();
            var recommendations = graph.GetRecommendations();

            // assert
            Assert.AreEqual(0, recommendations.Recommendations.Count);
        }

        [Test()]
        public void GraphWithElevenNodesShouldHaveRecommendations()
        {
            // arrange
            var fileContent =
                "nodedef>name VARCHAR,label VARCHAR,sex VARCHAR,locale VARCHAR,agerank INT" + Environment.NewLine +
                "1,Milena,female,es_LA,11" + Environment.NewLine +
                "2,Monica,female,es_LA,10" + Environment.NewLine +
                "3,Juana,female,es_LA,9" + Environment.NewLine +
                "4,Carlos,male,es_LA,8" + Environment.NewLine +
                "5,Esteban,male,es_LA,7" + Environment.NewLine +
                "6,Pablo,male,es_LA,6" + Environment.NewLine +
                "7,Lorena,female,es_LA,5" + Environment.NewLine +
                "8,Tomas,male,es_LA,4" + Environment.NewLine +
                "9,Brenda,female,es_LA,3" + Environment.NewLine +
                "10,Nora,female,es_LA,2" + Environment.NewLine +
                "11,Roberto,male,es_LA,1" + Environment.NewLine +
                "edgedef>node1 VARCHAR,node2 VARCHAR" + Environment.NewLine +
                "1,11" + Environment.NewLine +
                "1,5" + Environment.NewLine +
                "1,6" + Environment.NewLine +
                "2,5" + Environment.NewLine +
                "2,9" + Environment.NewLine +
                "2,11" + Environment.NewLine +
                "3,11" + Environment.NewLine +
                "3,10" + Environment.NewLine +
                "3,7" + Environment.NewLine +
                "3,8" + Environment.NewLine +
                "3,4" + Environment.NewLine +
                "4,8" + Environment.NewLine +
                "4,6" + Environment.NewLine +
                "4,5" + Environment.NewLine +
                "5,6" + Environment.NewLine +
                "7,11" + Environment.NewLine +
                "9,11" + Environment.NewLine;

            var builder = new GraphBuilder(new StringGraphReader(fileContent));
            var g = builder.Build();

            // act
            var recommendations = g.GetRecommendationsUsingBfs();
            var recommendationsForCarlos = recommendations.Recommendations.FirstOrDefault(r => r.Person.Data.Name == "Carlos");

            // assert
            Assert.IsNotNull(recommendationsForCarlos);
            Assert.AreEqual("Milena", recommendationsForCarlos.PersonToRecommend.Data.Name);
            Assert.AreEqual(2, recommendationsForCarlos.FriendCount);
        }
    }
}