using System;
using System.Collections.Generic;
using System.Linq;
using TP1.Graph;
using tp1.Recommendations;

namespace TP1.Recommendations
{
    public static class RecommendationsExtension
    {
        public static IEnumerable<Recommendation<TData, TId>> Recommendations<TData, TId>(this Graph<TData, TId> graph)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var recommendations = new List<Recommendation<TData, TId>>();
            foreach (var node in graph.Nodes)
            {
                Recommendation<TData, TId> recommendation = new Recommendation<TData, TId> { Person = node };

                foreach (var node2 in graph.Nodes)
                {
                    // it's not the same node and it's not a friend
                    if (node.Id.CompareTo(node2.Id) != 0 && !node.Adjacents.ContainsKey(node2.Id))
                    {
                        // count the number of friends in common
                        var currentCount = node.Adjacents.Keys.Count(id => node2.Adjacents.ContainsKey(id));

                        // update recommendation
                        if (currentCount > recommendation.FriendCount)
                        {
                            recommendation.PersonToRecommend = node2;
                            recommendation.FriendCount = currentCount;
                        }
                    }
                }

                if (recommendation.PersonToRecommend != null)
                {
                    recommendations.Add(recommendation);
                }
            }
            return recommendations;
        }
    }
}

