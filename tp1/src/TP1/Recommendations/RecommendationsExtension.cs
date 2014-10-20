using System;
using System.Linq;
using TP1.Graph;

namespace TP1.Recommendations
{
    public static class RecommendationsExtension
    {
		/// <remarks>O(N^3)
		/// </remarks>
        public static RecommendationsCollection<TData, TId> GetRecommendations<TData, TId>(this Graph<TData, TId> graph)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var recommendations = new RecommendationsCollection<TData, TId>();

			// O(N)
            foreach (var node in graph.Nodes)
            {
                Recommendation<TData, TId> recommendation = new Recommendation<TData, TId> { Person = node };

				// O(N)
                foreach (var node2 in graph.Nodes)
                {
                    // it's not the same node and it's not a friend
                    if (node.Id.CompareTo(node2.Id) != 0 && !node.Adjacents.ContainsKey(node2.Id))
                    {
                        // count the number of friends in common - O(N)
                        var currentCount = node.Adjacents.Keys.Count(id => node2.Adjacents.ContainsKey(id));

                        // update recommendation
                        if (currentCount > recommendation.FriendCount)
                        {
                            recommendation.PersonToRecommend = node2;
                            recommendation.FriendCount = currentCount;
                        }
                    }
                }

				recommendations.Add(recommendation); // O(1)
            }
            return recommendations;
        }
    }
}