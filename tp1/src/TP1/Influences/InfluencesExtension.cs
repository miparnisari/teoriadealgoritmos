using System;
using System.Linq;
using TP1.Graph;

namespace TP1.Influences
{
    public static class InfluencesExtension
    {
        /// <remarks>O(N^4)
        /// </remarks>
        public static InfluencesCollection<TData, TId> GetInfluences<TData, TId>(this Graph<TData, TId> graph)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var shortestPaths = GetTotalShortestPaths(graph); 

            double bottom = shortestPaths.Count;

            var influences = new InfluencesCollection<TData, TId>(graph.NodeCount);

            foreach (var node in graph.Nodes)
            {
                double top = shortestPaths.Paths.Count(p => p.PassesThrough(node));

                double influence = top/bottom; 

                influences.Add(new Influence<TData, TId>(node, influence));
            }

            return influences;
        }

        /// <remarks>O(N^4)
        /// </remarks>
        private static ShortestPathsCollection<TData, TId> GetTotalShortestPaths<TData, TId>(Graph<TData, TId> graph)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var allShortestPaths = new ShortestPathsCollection<TData, TId>(graph.EdgeCount);

            foreach (var nodeS in graph.Nodes) // O(N) * O(N^3) = O(N^4)
            {
                var shortestPaths = graph.GetShortestPathsWithBFS(nodeS); // O(N^3)

                allShortestPaths.Add(shortestPaths);
            }

            return allShortestPaths;
        }
    }
}
