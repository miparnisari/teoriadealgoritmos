using System;
using System.Collections.Generic;
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
            double influence = 0;
            foreach (var nodeS in graph.Nodes)
            {
                foreach (var nodeT in graph.Nodes)
                {
                    var shortestPaths = graph.GetShortestPathsWithDijkstra(nodeS, nodeT);

                    float bst = shortestPaths.Count;
                    float bsvt = shortestPaths.Count(path => path.Contains(nodeV));

                    influence += (bsvt / bst);
                }
            }
            return influence;
        }
    }
}
