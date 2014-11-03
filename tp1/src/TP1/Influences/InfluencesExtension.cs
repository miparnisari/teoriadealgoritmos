using System;
using System.Linq;
using TP1.Graph;

namespace TP1.Influences
{
    public static class InfluencesExtension
    {
        /// <remarks>O(|E||V|^3) average case
        /// </remarks>
        public static InfluencesCollection<TData, TId> GetInfluences<TData, TId>(this Graph<TData, TId> graph)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var shortestPaths = GetTotalShortestPaths(graph); // O(|E||V|^3) average case

            double bottom = shortestPaths.Count;

            var influences = new InfluencesCollection<TData, TId>(graph.NodeCount);

            foreach (var node in graph.Nodes) // O(|V|) * O((V*(V-1))/2) = O((V^2 * (V-1))/2) 
            {
                double top = shortestPaths.Paths.Count(p => p.PassesThrough(node)); // O((V*(V-1))/2) average case

                double influence = top/bottom; 

                influences.Add(new Influence<TData, TId>(node, influence));
            }

            return influences;
        }

        /// <remarks>O(|E||V|^3)
        /// </remarks>
        private static ShortestPathsCollection<TData, TId> GetTotalShortestPaths<TData, TId>(Graph<TData, TId> graph)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var allShortestPaths = new ShortestPathsCollection<TData, TId>(graph.EdgeCount);

            foreach (var nodeS in graph.Nodes) // O(|V|) * O(|E||V|^2) = O(|E||V|^3)
            {
                var shortestPaths = graph.GetShortestPathsWithBFS(nodeS); // O(|E||V|^2)

                allShortestPaths.Add(shortestPaths);
            }

            return allShortestPaths;
        }
    }
}
