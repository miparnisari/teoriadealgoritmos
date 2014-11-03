﻿using System;
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
            var distanceTo = new Dictionary<TId, long>();

            // stores the node(s) used to reach a given node 
            // since we are finding *all* the shortest paths, we store them all, not just one
            var previous = new Dictionary<TId, HashSet<Node<TData, TId>>>(graph.NodeCount); // O(1)
            foreach (var node in graph.Nodes)
            {
                node.Visited = false;
                previous[node.Id] = new HashSet<Node<TData, TId>>();
                if (!node.Equals(source))
                {
                    distanceTo[node.Id] = infinity;
                }
            }
            #endregion

            distanceTo[source.Id] = 0;
            unvisitedNodesQueue.Enqueue(source);

            while (unvisitedNodesQueue.Count > 0)
            {
                var visitedNode = unvisitedNodesQueue.Dequeue();

                visitedNode.Visited = true;

                // Visit the node's neighbors
                foreach (var adjacent in graph[visitedNode.Id].Adjacents)
                {
                    var currentDistance = distanceTo[visitedNode.Id] + 1;

                    // The node has not yet been discovered by BFS or it is the source node itself
                    if (!adjacent.Value.Visited && currentDistance <= distanceTo[adjacent.Key])
                    {
                        distanceTo[adjacent.Key] = currentDistance;

                        previous[adjacent.Value.Id].Add(graph[visitedNode.Id]); // Best case O(1), worst case O(N) - http://msdn.microsoft.com/en-us/library/bb353005(v=vs.110).aspx

                        unvisitedNodesQueue.Enqueue(adjacent.Value);
                    }
                }
            }

            // reconstruct the paths to each target
            var result = new ShortestPathsCollection<TData, TId>(graph.EdgeCount);
            foreach (var target in graph.Nodes.Except(new[] { source }))
            {
                var allPaths = FindParents(graph, previous, target);
                result.Add(allPaths);
            }
            return result;
        }

        /// <remarks>O(N^2) worst case
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

        /// <remarks>O(N^2) worst case
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
                newShortestPath.Path.Reverse(); // Worst case: O(N)
                results.Add(newShortestPath);
                return;
            }
            foreach (var previous in parent[target.Id]) // Worst case: O(N)
            {
                FindParentsRecursive(parent, previous, newShortestPath, results);
            }
        }
    }
}
