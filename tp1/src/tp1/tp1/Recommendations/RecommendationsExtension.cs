using System;
using System.Collections.Generic;
using TP1.Graph;

namespace TP1.Recommendations
{
	public static class RecommendationsExtension
	{
		public static IEnumerable<Tuple<Node<TData, TId>, Node<TData, TId>, int>> Recommendations<TData, TId>(this Graph<TData, TId> graph)
			where TData: IIdentifiable<TId>
			where TId: IComparable
		{
			var recommendations = new List<Tuple<Node<TData, TId>, Node<TData, TId>, int>>();
			foreach(var node in graph.Nodes)
			{
				Node<TData, TId> recommendation = null;
				int maxCount = 0;
				foreach(var node2 in graph.Nodes) 
				{
					// it's not the same node and it's not a friend
					if (node.Id.CompareTo(node2.Id) != 0 && !node.Adjacents.ContainsKey(node2.Id)) 
					{
						// count the number of friends in common
						var currentCount = 0;
						foreach(var id in node.Adjacents.Keys) 
						{
							if (node2.Adjacents.ContainsKey(id))
								currentCount++;
						}
						// update recommendation
						if (currentCount > maxCount) {
							recommendation = node2;
							maxCount = currentCount;
						}
					}
				}
				if (recommendation !=null) {
					recommendations.Add(Tuple.Create<Node<TData, TId>, Node<TData, TId>, int>(node, recommendation, maxCount));
				}
			}
			return recommendations;
		}
	}
}

