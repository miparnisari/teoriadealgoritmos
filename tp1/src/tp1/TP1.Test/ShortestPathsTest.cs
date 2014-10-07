using System;
using System.Linq;
using TP1.GraphReader;
using NUnit.Framework;
using TP1.Influences;

namespace TP1.Test
{
    [TestFixture()]
    public class ShortestPathsTest
    {
        [Test()]
        public void ShouldGetOneShortestPathOfLengthThree()
        {
            // arrange
            var builder = new GraphBuilder(new GraphReader.GraphReader(@"Input\test.txt"));
            var graph = builder.Build();

            // act
            var source = graph[3]; //Juana
            var destination = graph[1]; //Milena

            var shortestPaths = graph.GetShortestPathsWithDijkstra(source, destination);

            // assert
            Assert.AreEqual(1, shortestPaths.Count);
            Assert.AreEqual(3, shortestPaths[0].Length);
            Assert.AreEqual(graph[3], shortestPaths[0][0]); //Juana
            Assert.AreEqual(graph[11], shortestPaths[0][1]); //Roberto
            Assert.AreEqual(graph[1], shortestPaths[0][2]); //Milena
        }

        [Test()]
        public void ShouldGetZeroShortestPaths_WhenNodesAreTheSame()
        {
            // arrange
            var builder = new GraphBuilder(new GraphReader.GraphReader(@"Input\test.txt"));
            var graph = builder.Build();

            // act
            var source = graph[3]; //Juana
            var destination = graph[3]; //Juana

            var shortestPaths = graph.GetShortestPathsWithDijkstra(source, destination);

            // assert
            Assert.AreEqual(0, shortestPaths.Count);
        }

        [Test()]
        public void ShouldGetOneShortestPathReversed()
        {
            // arrange
            var builder = new GraphBuilder(new GraphReader.GraphReader(@"Input\test.txt"));
            var graph = builder.Build();

            // act
            var source = graph[2]; //Monica
            var destination = graph[3]; //Juana

            var shortestPaths = graph.GetShortestPathsWithDijkstra(source, destination);
            var shortestPathsReversed = graph.GetShortestPathsWithDijkstra(destination, source);
            shortestPathsReversed.Paths.First().Path.Reverse();
            
            // assert
            Assert.AreEqual(shortestPaths.Paths.First().Path, shortestPathsReversed.Paths.First().Path);
        }

        [Test()]
        public void ShouldGetTwoShortestPathsOfLengthThree()
        {
            // arrange
            var builder = new GraphBuilder(new GraphReader.GraphReader(@"Input\test.txt"));
            var graph = builder.Build();

            // act
            var source = graph[1]; // Milena
            var destination = graph[2]; //Monica

            var shortestPaths = graph.GetShortestPathsWithDijkstra(source, destination);

            // assert
            Assert.AreEqual(2, shortestPaths.Count);
            Assert.AreEqual(3, shortestPaths[0].Length);
            Assert.AreEqual(graph[1], shortestPaths[0][0]); //Milena
            Assert.AreEqual(graph[5], shortestPaths[0][1]); //Esteban
            Assert.AreEqual(graph[2], shortestPaths[0][2]); //Monica

            Assert.AreEqual(3, shortestPaths[1].Length);
            Assert.AreEqual(graph[1], shortestPaths[1][0]); //Milena
            Assert.AreEqual(graph[11], shortestPaths[1][1]); //Roberto
            Assert.AreEqual(graph[2], shortestPaths[1][2]); //Monica
        }

        [Test()]
        public void ShouldGetZeroShortestPaths_WhenNodesAreNotAdjacent()
        {
            // arrange
            var fileContent =
                "nodedef>name VARCHAR,label VARCHAR,sex VARCHAR,locale VARCHAR,agerank INT" + Environment.NewLine +
                "1,Juan,male,es_LA,2" + Environment.NewLine +
                "2,Maria,female,es_LA,1" + Environment.NewLine +
                "edgedef>node1 VARCHAR,node2 VARCHAR" + Environment.NewLine;

            var builder = new GraphBuilder(new StringGraphReader(fileContent));
            var graph = builder.Build();

            // act
            var source = graph[1]; // Juana
            var destination = graph[2]; //Maria

            var shortestPaths = graph.GetShortestPathsWithDijkstra(source, destination);

            // assert
            Assert.AreEqual(0, shortestPaths.Count);
        }
    }
}
