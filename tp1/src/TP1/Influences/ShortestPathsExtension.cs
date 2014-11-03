using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TP1.Graph;

namespace TP1.Influences
{
    public static class ShortestPathsExtension
    {
        const long infinity = int.MaxValue - 1;

        /// <summary>
        /// Returns all the shortest paths from a node to every other node in a graph.
        /// If the nodes's IDs are equal, it returns an empty collection.
        /// </summary>
        /// Orden: O(|E||V|^2)
        /// <remarks>
        /// </remarks>
        public static ShortestPathsCollection<TData, TId> GetShortestPathsWithBFS<TData, TId>
            (this Graph<TData, TId> graph,
                Node<TData, TId> source)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            #region initialize data structures and variables

            // stores each unvisited node
            var unvisitedNodesQueue = new Queue<Node<TData, TId>>(graph.NodeCount); // O(1)

            // stores the shortest distance to each node, from "source"
            var distanceTo = new Dictionary<TId, long>(graph.NodeCount); // O(1)

            // stores the node(s) used to reach a given node 
            // since we are finding *all* the shortest paths, we store them all, not just one
            var previous = new Dictionary<TId, HashSet<Node<TData, TId>>>(graph.NodeCount); // O(1)
            foreach (var node in graph.Nodes) // O(V)
            {
                node.Visited = false;
                previous[node.Id] = new HashSet<Node<TData, TId>>(); // 0(1)
                if (!node.Equals(source))
                {
                    distanceTo[node.Id] = infinity;
                }
            }
            #endregion

            distanceTo[source.Id] = 0;
            unvisitedNodesQueue.Enqueue(source);

            while (unvisitedNodesQueue.Count > 0) // Each node will be visited at most once, so O(|V|)*O(|E|) = O(|V||E|)
            {
                var visitedNode = unvisitedNodesQueue.Dequeue(); // O(1) - http://msdn.microsoft.com/es-es/library/1c8bzx97(v=vs.110).aspx

                visitedNode.Visited = true;

                // Visit the node's neighbors
                foreach (var adjacent in graph[visitedNode.Id].Adjacents) // O(|E|) average case
                {
                    var currentDistance = distanceTo[visitedNode.Id] + 1;

                    // The node has not yet been discovered by BFS or it is the source node itself
                    if (!adjacent.Value.Visited && currentDistance <= distanceTo[adjacent.Key]) // O(1)
                    {
                        distanceTo[adjacent.Key] = currentDistance;

                        previous[adjacent.Value.Id].Add(graph[visitedNode.Id]); // Average case O(1) - http://msdn.microsoft.com/en-us/library/bb353005(v=vs.110).aspx

                        unvisitedNodesQueue.Enqueue(adjacent.Value); // O(1) - http://msdn.microsoft.com/es-es/library/t249c2y7(v=vs.110).aspx
                    }
                }
            }

            // reconstruct the paths to each target
            var result = new ShortestPathsCollection<TData, TId>(graph.EdgeCount);
            foreach (var target in graph.Nodes.Except(new[] { source })) // O(|V|)*O(|E||V|) = O(|E||V|^2)
            {
                var allPaths = FindParents(graph, previous, target); // O(|E||V|) average case
                result.Add(allPaths);
            }
            return result;
        }

        /// <remarks>O(|E||V|) average case
        /// </remarks>
        private static ShortestPathsCollection<TData, TId> FindParents<TData, TId>
             (Graph<TData, TId> graph,
            Dictionary<TId, HashSet<Node<TData, TId>>> parent,
             Node<TData, TId> target)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var prefix = new ShortestPath<TData, TId>();
            var results = new ShortestPathsCollection<TData, TId>(graph.NodeCount);
            FindParentsRecursive(parent, target, prefix, results);
            return results;
        }

        /// <remarks>O(|E||V|) average case
        /// </remarks>
        private static void FindParentsRecursive<TData, TId>
            (Dictionary<TId, HashSet<Node<TData, TId>>> parent,
            Node<TData, TId> target,
            ShortestPath<TData, TId> prefix,
            ShortestPathsCollection<TData, TId> results)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var newShortestPath = new ShortestPath<TData, TId>();
            newShortestPath.Path.AddRange(prefix.Path);
            newShortestPath.Path.Add(target);
            if (parent[target.Id].Count == 0 && newShortestPath.Length > 1)
            {
                newShortestPath.Path.Reverse(); // Average case: O(|V|/2)
                results.Add(newShortestPath);
                return;
            }
            foreach (var previous in parent[target.Id]) // Average case: O(|E|/2)
            {
                FindParentsRecursive(parent, previous, newShortestPath, results);
            }
        }
    }
}
