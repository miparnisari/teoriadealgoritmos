﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TP1.Graph;

namespace tp1.Influences
{
    public static class InfluencesExtension
    {
        public static List<Tuple<Node<TData, TId>, double>> Influences<TData, TId>(this Graph<TData, TId> graph)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var influences = new List<Tuple<Node<TData, TId>, double>>();
            foreach (var node in graph.Nodes)
            {
                var influence = GetInfluenceForNode(graph, node);
                
                influences.Add(new Tuple<Node<TData, TId>, double>(node, influence));
            }

            return influences;
        }

        private static double GetInfluenceForNode<TData, TId>(Graph<TData, TId> graph, Node<TData, TId> nodeV)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var top = GetShortestPathsThatPassThroughNode(graph, nodeV);
            var bottom = GetTotalShortestPaths(graph);

            double topCount = top.Count;
            double bottomCount = bottom.Count;

            double result = topCount / bottomCount;

            return result;
        }

        private static List<ShortestPath<TData, TId>> GetTotalShortestPaths<TData, TId>(Graph<TData, TId> graph)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var paths = new List<ShortestPath<TData, TId>>();

            foreach (var nodeS in graph.Nodes)
            {
                Node<TData, TId> s = nodeS;
                foreach (var nodeT in graph.Nodes.Except(new[] { nodeS }).Where(n => !s.Adjacents.ContainsKey(n.Id)))
                {
                    var shortestPaths = graph.GetShortestPathsWithDijkstra(nodeS, nodeT);

                    paths.AddRange(shortestPaths);
                }
            }

            return paths;
        }

        private static List<ShortestPath<TData, TId>> GetShortestPathsThatPassThroughNode<TData, TId>(Graph<TData, TId> graph, Node<TData, TId> node)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var paths = new List<ShortestPath<TData, TId>>();

            foreach (var nodeS in graph.Nodes)
            {
                Node<TData, TId> s = nodeS;
                foreach (var nodeT in graph.Nodes.Except(new[] { nodeS }).Where(n => !s.Adjacents.ContainsKey(n.Id)))
                {
                    var shortestPaths = graph.GetShortestPathsWithDijkstra(nodeS, nodeT);

                    var shortestsPathsWithNode = shortestPaths.Where(p => p.PassesThrough(node));

                    paths.AddRange(shortestsPathsWithNode);
                }
            }

            return paths;
        }
    }
}
