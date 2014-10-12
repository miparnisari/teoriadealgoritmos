using System;
using System.Collections.Generic;
using System.Linq;
using TP1.Graph;

namespace TP1.Influences
{
    public static class ShortestPathsExtension
    {
        /// <summary>
        /// Returns all the shortest paths between two given nodes in a graph.
        /// If the nodes's IDs are equal, it returns an empty collection.
        /// </summary>
        public static ShortestPathsCollection<TData, TId> GetShortestPathsWithDijkstra<TData, TId>
            (this Graph<TData, TId> graph,
                Node<TData, TId> source)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            // stores the shortest distance to each node, from "source"
            var distanceTo = new Dictionary<TId, long>();

            // stores each unvisited node, with its distance to the source
            var unvisitedNodes = new MinPriorityQueue<TId, long>(graph.Count);

            // stores the node(s) used to reach a given node 
            // since we are finding *all* the shortest paths, we store them all, not just one
            var previous = new Dictionary<TId, HashSet<Node<TData, TId>>>();

            distanceTo[source.Id] = 0;

            foreach (var node in graph.Nodes)
            {
                const long infinity = int.MaxValue - 1;
                if (!node.Equals(source))
                {
                    distanceTo[node.Id] = infinity;
                    previous[node.Id] = new HashSet<Node<TData, TId>>();
                }
                unvisitedNodes.InsertWithPriority(node.Id, distanceTo[node.Id]);
            }

            while (unvisitedNodes.ContainsElements())
            {
                // Select node with minimum distance from source
                var visitedNodeId = unvisitedNodes.Remove().data;

                foreach (var adjacent in graph[visitedNodeId].Adjacents)
                {
                    var currentDistance = distanceTo[visitedNodeId] + 1;

                    if (currentDistance <= distanceTo[adjacent.Key])
                    {
                        // A shorter or equally short path has been found!
                        distanceTo[adjacent.Key] = currentDistance;
                        previous[adjacent.Value.Id].Add(graph[visitedNodeId]);
                        unvisitedNodes.DecreasePriority(adjacent.Key, currentDistance);
                    }
                }
            }

            // reconstruct the paths to each target
            var result = new ShortestPathsCollection<TData, TId>();
            foreach (var target in graph.Nodes.Except(new[] { source }))
            {
                result.AddPaths(FindParents(previous, target));
            }
            return result;
        }

        private static ShortestPathsCollection<TData, TId> FindParents<TData, TId>
             (Dictionary<TId, HashSet<Node<TData, TId>>> parent,
             Node<TData, TId> index)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var prefix = new ShortestPath<TData, TId>();
            var results = new ShortestPathsCollection<TData, TId>();
            FindParentsRecursive(parent, index, prefix, results);
            return results;
        }

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
                newShortestPath.Path.Reverse();
                results.Paths.Add(newShortestPath);
                return;
            }
            foreach (var previous in parent[index.Id])
            {
                FindParentsRecursive(parent, previous, newShortestPath, results);
            }
        }
    }
}
