using System;
using System.Linq;
using TP1.GraphReader;
using NUnit.Framework;
using tp1.Influences;

namespace TP1.Test
{
    [TestFixture()]
    public class ShortestPathsTest
    {
        [Test()]
        public void ShouldGetOneShortestPath()
        {
            // arrange
            var builder = new GraphBuilder(new GraphReader.GraphReader(@"Input\test.txt"));
            var graph = builder.Build();

            // act
            var source = graph[3];
            var destination = graph[1];

            var shortestPathsToDestination = graph.GetShortestPathsWithDijkstra(source, destination);

            // assert
            Assert.AreEqual(1, shortestPathsToDestination.Count());
            Assert.AreEqual(graph[3], shortestPathsToDestination[0][0]);
            Assert.AreEqual(graph[11], shortestPathsToDestination[0][1]);
            Assert.AreEqual(graph[1], shortestPathsToDestination[0][2]);
        }

        [Test()]
        public void ShouldGetOneShortestPath2()
        {
            // arrange
            var builder = new GraphBuilder(new GraphReader.GraphReader(@"Input\test.txt"));
            var graph = builder.Build();

            // act
            var source = graph[3];
            var destination = graph[2];

            var shortestPathsToDestination = graph.GetShortestPathsWithDijkstra(source, destination);

            // assert
            Assert.AreEqual(1, shortestPathsToDestination.Count());
            Assert.AreEqual(graph[3], shortestPathsToDestination[0][0]);
            Assert.AreEqual(graph[11], shortestPathsToDestination[0][1]);
            Assert.AreEqual(graph[2], shortestPathsToDestination[0][2]);
        }

        [Test()]
        public void ShouldGetOneShortestPath2Reversed()
        {
            // arrange
            var builder = new GraphBuilder(new GraphReader.GraphReader(@"Input\test.txt"));
            var graph = builder.Build();

            // act
            var source = graph[2];
            var destination = graph[3];

            var shortestPathsToDestination = graph.GetShortestPathsWithDijkstra(source, destination);
            //TODO this should return one path (the shortest) not all

            // assert
            Assert.AreEqual(1, shortestPathsToDestination.Count());
            Assert.AreEqual(graph[2], shortestPathsToDestination[0][0]);
            Assert.AreEqual(graph[11], shortestPathsToDestination[0][1]);
            Assert.AreEqual(graph[3], shortestPathsToDestination[0][2]);
        }
    }
}
