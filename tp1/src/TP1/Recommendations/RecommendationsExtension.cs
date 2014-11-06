using System;
using System.Collections.Generic;
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

		/// <remarks>O(N^2 + NE)
		/// </remarks>
		public static RecommendationsCollection<TData, TId> GetRecommendationsUsingBfs<TData, TId>(this Graph<TData, TId> graph)
			where TData : IIdentifiable<TId>
				where TId : IComparable
		{
			var recommendations = new RecommendationsCollection<TData, TId>();

			// O(N)
			foreach (var node in graph.Nodes)
			{
				// O(N + E) where N is the number of nodes and E the number of edges
				Recommendation<TData, TId> recommendation = Bfs (graph, node);

				if (recommendation.PersonToRecommend != null)
					recommendations.Add(recommendation); // O(1)
			}
			return recommendations;
		}

		private static Recommendation<TData, TId>  Bfs<TData, TId>(Graph<TData, TId> graph, Node<TData, TId> root)
			where TData : IIdentifiable<TId>
			where TId : IComparable
		{
			var recomendation = new Recommendation<TData, TId> { Person = root };
			var nodesCount = graph.Nodes.Count();
			// queue holding node and the level in the BFS tree
			var queue = new Queue<Tuple<int, Node<TData,TId>>>(nodesCount);
			queue.Enqueue (Tuple.Create(0, root));
			// nodes already visited by bfs
			var visited = new Dictionary<TId, Node<TData,TId>>(nodesCount){ { root.Id, root } };
			// friends in common
			var friendsInCommon = new Dictionary<TId, int>(nodesCount);
			// O(N) where N is the number of nodes
			while (queue.Any()) 
			{
				var t = queue.Dequeue (); // O(1)
				// stop looping at third level of the bfs tree
				if (t.Item1 == 3) 
					break;
				// O(En) where En is the number of adjacents nodes to Node n.
				foreach (var adj in t.Item2.Adjacents) 
				{
					if (!visited.ContainsKey (adj.Key)) { // O(1)
						visited.Add (adj.Key, adj.Value); // O(1)
						queue.Enqueue (Tuple.Create(t.Item1 + 1, adj.Value)); // O(1)
					}
					// t is at L1 and adj is at L2 - O(1)
					if (t.Item1 == 1 && 
					    !adj.Value.Equals(root) &&  // O(1)
					    !root.Adjacents.ContainsKey(adj.Value.Id)) { // O(1)
						// update the friends count of the nodes at L2
						if (!friendsInCommon.ContainsKey(adj.Value.Id))  // O(1)
							friendsInCommon.Add(adj.Value.Id, 0); // O(1)
						friendsInCommon[adj.Value.Id] += 1; // O(1)
						// update recommendation - O(1)
						if (friendsInCommon [adj.Value.Id] > recomendation.FriendCount) 
						{
							recomendation.FriendCount = friendsInCommon [adj.Value.Id];
							recomendation.PersonToRecommend = adj.Value;
						}
					}
				}
			}

			return recomendation;
		}
    }
}