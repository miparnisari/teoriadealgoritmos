using System;
using System.Collections.Generic;
using System.Linq;
using TP1.Graph;

namespace TP1.Influences
{
    public static class ShortestPathsExtension
    {
        /// <summary>
        /// Returns all the shortest paths from a node to every other node in a graph.
        /// If the nodes's IDs are equal, it returns an empty collection.
        /// </summary>
        /// <remarks>O(N log N) + O(N^3 log N) + O(N^3) = O(N^3)
        /// N: node count for the graph
        /// E: edge count for the graph
        /// </remarks>
        public static ShortestPathsCollection<TData, TId> GetShortestPathsWithDijkstra<TData, TId>
            (this Graph<TData, TId> graph,
                Node<TData, TId> source)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            #region initialize data structures
            // stores the shortest distance to each node, from "source"
            var distanceTo = new Dictionary<TId, long>(graph.NodeCount); // O(1) - source: http://msdn.microsoft.com/en-us/library/tk84bxf4(v=vs.110).aspx

            // stores each unvisited node, with its distance to the source
            var unvisitedNodes = new MinPriorityQueue<TId, long>(graph.NodeCount); // O(1)

            // stores the node(s) used to reach a given node 
            // since we are finding *all* the shortest paths, we store them all, not just one
            var previous = new Dictionary<TId, HashSet<Node<TData, TId>>>(graph.NodeCount); // O(1)
            #endregion
            distanceTo[source.Id] = 0;

            foreach (var node in graph.Nodes) // O(N) * O(log N) = O(N log N)
            {
                const long infinity = long.MaxValue - 1;
                if (!node.Equals(source))
                {
                    distanceTo[node.Id] = infinity;
                    previous[node.Id] = new HashSet<Node<TData, TId>>();
                }
                unvisitedNodes.InsertWithPriority(node.Id, distanceTo[node.Id]); // O(log N)
            }

            while (unvisitedNodes.ContainsElements()) // O(N) * [O(N^2 log N) + O(log N)] = O(N^3 log N)
            {
                // Select node with minimum distance from source
                var visitedNodeId = unvisitedNodes.Remove().data; // O(log N)

                foreach (var adjacent in graph[visitedNodeId].Adjacents) // O(N) * O(N log N) = O(N^2 log N)
                {
                    var currentDistance = distanceTo[visitedNodeId] + 1;

                    if (currentDistance <= distanceTo[adjacent.Key])
                    {
                        // A shorter or equally short path has been found!
                        distanceTo[adjacent.Key] = currentDistance;
                        previous[adjacent.Value.Id].Add(graph[visitedNodeId]); // Best case O(1), worst case O(N) - http://msdn.microsoft.com/en-us/library/bb353005(v=vs.110).aspx
                        unvisitedNodes.IncreasePriority(adjacent.Key, currentDistance); // O(N log N)
                    }
                }
            }

            // reconstruct the paths to each target
            var result = new ShortestPathsCollection<TData, TId>(graph.EdgeCount);
            foreach (var target in graph.Nodes.Except(new[] { source })) // O(N) * O(N^2) = O(N^3)
            {
                var paths = FindParents(graph, previous, target); //O(N^2) worst case
                result.AddPaths(paths);
            }
            return result;
        }

        /// <remarks>O(N^2) worst case
        /// </remarks>
        private static ShortestPathsCollection<TData, TId> FindParents<TData, TId>
             (Graph<TData, TId> graph,
            Dictionary<TId, HashSet<Node<TData, TId>>> parent,
             Node<TData, TId> index)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var prefix = new ShortestPath<TData, TId>();
            var results = new ShortestPathsCollection<TData, TId>(graph.NodeCount);
            FindParentsRecursive(parent, index, prefix, results);
            return results;
        }

        /// <remarks>O(N^2) worst case
        /// </remarks>
        private static void FindParentsRecursive<TData, TId>
            (Dictionary<TId, HashSet<Node<TData, TId>>> parent,
            Node<TData, TId> index,
            ShortestPath<TData, TId> prefix,
            ShortestPathsCollection<TData, TId> results)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var newShortestPath = new ShortestPath<TData, TId>();
            newShortestPath.Path.AddRange(prefix.Path);
            newShortestPath.Path.Add(index);
            if (!parent.ContainsKey(index.Id))
            {
                newShortestPath.Path.Reverse(); // Worst case: O(N)
                results.Paths.Add(newShortestPath);
                return;
            }
            foreach (var previous in parent[index.Id]) // Worst case: O(N)
            {
                FindParentsRecursive(parent, previous, newShortestPath, results);
            }
        }
    }
}
