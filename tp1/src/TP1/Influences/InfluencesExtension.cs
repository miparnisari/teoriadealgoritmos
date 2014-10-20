using System;
using System.Linq;
using TP1.Graph;

namespace TP1.Influences
{
    public static class InfluencesExtension
    {
        public static InfluencesCollection<TData, TId> GetInfluences<TData, TId>(this Graph<TData, TId> graph)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var shortestPaths = GetTotalShortestPaths(graph);

            double bottom = shortestPaths.Count;

            var influences = new InfluencesCollection<TData, TId>();
            
            foreach (var node in graph.Nodes)
            {
                double top = shortestPaths.Paths.Count(p => p.PassesThrough(node));

                double influence = top/bottom; 

                influences.Add(new Influence<TData, TId>(node, influence));
            }

            return influences;
        }

        private static ShortestPathsCollection<TData, TId> GetTotalShortestPaths<TData, TId>(Graph<TData, TId> graph)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var allShortestPaths = new ShortestPathsCollection<TData, TId>(graph.EdgeCount);

            foreach (var nodeS in graph.Nodes)
            {
                var shortestPaths = graph.GetShortestPathsWithDijkstra(nodeS);

                allShortestPaths.AddPaths(shortestPaths);
            }

            return allShortestPaths;
        }
    }
}
