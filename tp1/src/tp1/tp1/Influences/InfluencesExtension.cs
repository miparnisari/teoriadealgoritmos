using System;
using System.Linq;
using TP1.Graph;

namespace TP1.Influences
{
    public static class InfluencesExtension
    {
        public static InfluencesCollection<TData, TId> Influences<TData, TId>(this Graph<TData, TId> graph)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            int bottom = GetTotalShortestPaths(graph)
                .Count;

            var influences = new InfluencesCollection<TData, TId>();
            foreach (var node in graph.Nodes)
            {
                double top = GetShortestPathsThatPassThroughNode(graph, node).Count;

                double influence = top/bottom; 

                influences.Add(new Influence<TData, TId>(node, influence));
            }

            return influences;
        }

        public static ShortestPathsCollection<TData, TId> GetTotalShortestPaths<TData, TId>(Graph<TData, TId> graph)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var allShortestPaths = new ShortestPathsCollection<TData, TId>();

            foreach (var nodeS in graph.Nodes)
            {
                foreach (var nodeT in graph.Nodes.Except(new[] { nodeS }))
                {
                    var shortestPaths = graph.GetShortestPathsWithDijkstra(nodeS, nodeT);

                    allShortestPaths.AddPaths(shortestPaths);
                }
            }

            return allShortestPaths;
        }

        private static ShortestPathsCollection<TData, TId> GetShortestPathsThatPassThroughNode<TData, TId>(Graph<TData, TId> graph, Node<TData, TId> node)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var paths = new ShortestPathsCollection<TData, TId>();

            foreach (var nodeS in graph.Nodes)
            {
                foreach (var nodeT in graph.Nodes.Except(new[] { nodeS }))
                {
                    var shortestPaths = graph.GetShortestPathsWithDijkstra(nodeS, nodeT);

                    var shortestsPathsWithNode = shortestPaths.Paths.Where(p => p.PassesThrough(node));

                    paths.AddPaths(shortestsPathsWithNode);
                }
            }

            return paths;
        }
    }
}
