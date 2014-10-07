using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                Node<TData, TId> source,
                Node<TData, TId> target)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            // there is no path from a node to itself
            if (source.Id.Equals(target.Id))
            {
                return new ShortestPathsCollection<TData, TId>();
            }

            // stores the shortest distance to each node, from "source"
            var distanceTo = new Dictionary<Node<TData, TId>, long>();

            var unvisitedNodes = new HashSet<Node<TData, TId>>(); //TODO improve with min-priority queue

            // stores the node(s) used to reach a given node 
            // since we are finding *all* the shortest paths, we store them all, not just one
            var previous = new Dictionary<TId, List<Node<TData, TId>>>();

            distanceTo[source] = 0;

            foreach (var node in graph.Nodes)
            {
                if (!node.Equals(source))
                {
                    distanceTo[node] = Int64.MaxValue - 1;
                    previous[node.Id] = new List<Node<TData, TId>>();
                }
                unvisitedNodes.Add(node);
            }

            while (unvisitedNodes.Any())
            {
                // Select node with minimum distance from source
                var visitedNode = distanceTo
                    .OrderBy(i => i.Value)
                    .First(n => unvisitedNodes.Contains(n.Key))
                    .Key;

                unvisitedNodes.Remove(visitedNode);

                foreach (var adjacent in visitedNode.Adjacents)
                {
                    var currentDistance = distanceTo[visitedNode] + 1;

                    if (currentDistance <= distanceTo[adjacent.Value])
                    {
                        // A shorter or equally short path has been found!
                        distanceTo[adjacent.Value] = currentDistance;
                        previous[adjacent.Value.Id].Add(visitedNode);
                    }
                }
            }

            // reconstruct the paths to the source from the target
            return FindParents(previous, target);
        }

        private static ShortestPathsCollection<TData, TId> FindParents<TData, TId>
             (Dictionary<TId, List<Node<TData, TId>>> parent,
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
            (Dictionary<TId, List<Node<TData, TId>>> parent,
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
            parent[index.Id].ForEach(i => FindParentsRecursive(parent, i, newShortestPath, results));
        }
    }
}
