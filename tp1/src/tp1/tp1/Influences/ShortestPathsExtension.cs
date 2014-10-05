﻿using System;
using System.Collections.Generic;
using System.Linq;
using TP1.Graph;

namespace tp1.Influences
{
    public static class ShortestPathsExtension
    {
        public static List<List<Node<TData, TId>>> GetShortestPathsWithDijkstra<TData, TId>
            (this Graph<TData, TId> graph,
                Node<TData, TId> source,
                Node<TData, TId> target)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
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
                    distanceTo[node] = Int64.MaxValue;
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

            // reconstruct the path to the source from the target
            return FindParents(previous, target);
        }

       private static List<List<Node<TData, TId>>> FindParents<TData, TId>
            (Dictionary<TId, List<Node<TData, TId>>> parent,
            Node<TData, TId> index)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            List<Node<TData, TId>> prefix = new List<Node<TData, TId>>();
            List<List<Node<TData, TId>>> results = new List<List<Node<TData, TId>>>();
            FindParentsRecursive(parent, index, prefix, results);
            return results;
        }

        private static void FindParentsRecursive<TData, TId>
            (Dictionary<TId, List<Node<TData, TId>>> parent,
            Node<TData, TId> index,
            List<Node<TData, TId>> prefix,
            List<List<Node<TData, TId>>> results)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var newPrefix = new List<Node<TData, TId>>(prefix) { index };
            if (!parent.ContainsKey(index.Id))
            {
                newPrefix.Reverse();
                results.Add(newPrefix);
                return;
            }
            parent[index.Id].ForEach(i => FindParentsRecursive(parent, i, newPrefix, results));
        }
    }
}
