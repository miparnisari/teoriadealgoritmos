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
        public void ShouldGet14ShortestPaths_WhenSourceIdIsOne()
        {
            // arrange
            var builder = new GraphBuilder(new GraphReader.GraphReader(@"Input\test.txt"));
            var graph = builder.Build();

            // act
            var paths = graph.GetShortestPathsWithDijkstra(graph[1]);

            // assert
            Assert.AreEqual(14, paths.Count);
        }

        [Test()]
        public void ShouldGet12ShortestPaths_WhenSourceIdIsSix()
        {
            // arrange
            var builder = new GraphBuilder(new GraphReader.GraphReader(@"Input\test.txt"));
            var graph = builder.Build();

            // act
            var paths = graph.GetShortestPathsWithDijkstra(graph[6]);

            // assert
            Assert.AreEqual(12, paths.Count);
        }

        [Test()]
        public void ShouldGet132ShortestPaths()
        {
            // arrange
            var builder = new GraphBuilder(new GraphReader.GraphReader(@"Input\test.txt"));
            var graph = builder.Build();

            // act
            int sum = 0;
            foreach (var node in graph.Nodes)
            {
                var paths = graph.GetShortestPathsWithDijkstra(node);
                foreach (var path in paths)
                {
                    Console.WriteLine(path);
                }
                sum += paths.Count;
            }

            // assert
            Assert.AreEqual(132, sum);
        }

        [Test()]
        public void ShouldGetOneShortestPathOfLengthThree()
        {
            // arrange
            var builder = new GraphBuilder(new GraphReader.GraphReader(@"Input\test.txt"));
            var graph = builder.Build();

            // act
            var source = graph[3]; //Juana
            var destination = graph[1]; //Milena

            var shortestPaths = graph.GetShortestPathsWithDijkstra(source).Paths
                .Where(p => p.EndNode.Equals(destination))
                .ToList();

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

            var shortestPaths = graph.GetShortestPathsWithDijkstra(source).Paths
                .Where(p => p.EndNode.Equals(destination))
                .ToList();

            // assert
            Assert.AreEqual(0, shortestPaths.Count);
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

            var shortestPaths = graph.GetShortestPathsWithDijkstra(source).Paths
                .Where(p => p.EndNode.Equals(destination))
                .ToList();

            // assert
            Assert.AreEqual(2, shortestPaths.Count);
            Assert.AreEqual(3, shortestPaths[0].Length);
            Assert.AreEqual(graph[1], shortestPaths[0][0]); //Milena
            Assert.AreEqual(graph[11], shortestPaths[0][1]); //Esteban
            Assert.AreEqual(graph[2], shortestPaths[0][2]); //Monica

            Assert.AreEqual(3, shortestPaths[1].Length);
            Assert.AreEqual(graph[1], shortestPaths[1][0]); //Milena
            Assert.AreEqual(graph[5], shortestPaths[1][1]); //Roberto
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

            var shortestPaths = graph.GetShortestPathsWithDijkstra(source).Paths
                .Where(p => p.EndNode.Equals(destination))
                .ToList();

            // assert
            Assert.AreEqual(0, shortestPaths.Count);
        }
    }
}
