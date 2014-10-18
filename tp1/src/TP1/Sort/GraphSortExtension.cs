using System;
using System.Collections.Generic;
using System.Linq;
using TP1.Graph;

namespace TP1.Sort
{
	public static class GraphSortExtension
	{
		private static void Swap<TData, TId>(Node<TData, TId>[] nodes, int a, int b)
			where TData : IIdentifiable<TId>
				where TId : IComparable
		{
			var temp = nodes[a];
			nodes[a] = nodes[b];
			nodes[b] = temp;
		}

		private static void SiftDown<TData, TId>(Node<TData, TId>[] nodes, int start, int end, Func<Node<TData, TId>, Node<TData, TId>, bool> comparer)
			where TData : IIdentifiable<TId>
				where TId : IComparable
		{
			var root = start;
			while(root * 2 + 1 <= end) {
				var child = root * 2 + 1;
				var swap = root;
				if (comparer(nodes[swap], nodes[child]))
					swap = child;
				if (child + 1 <= end && comparer(nodes[swap], nodes[child + 1]))
					swap = child + 1;
				if (swap != root)
				{
					Swap(nodes, root, swap);
					root = swap;
				}
				else 
					return;
			}
		}

		/// <summary>
		/// Sort the specified graph.
		/// </summary>
		/// <param name='graph'>Graph to be sorted .</param>
		/// <param name='comparer'>Comparer.</param>
		/// <returns>A sorted list of nodes.</returns>
		public static IEnumerable<Node<TData, TId>> Sort<TData, TId>(this Graph<TData, TId> graph, Func<Node<TData, TId>, Node<TData, TId>, bool> comparer)
			where TData : IIdentifiable<TId>
			where TId : IComparable
		{
			var nodes = graph.Nodes.ToArray();
			var count = nodes.Count();

			// heapify
			var start = (int)Math.Floor((count - 2.0) / 2.0);
			while (start >= 0) {
				SiftDown(nodes, start, count-1, comparer);
				start = start - 1;
			}

			//sort
			var end = count - 1;
			while (end > 0) {
				Swap(nodes, end, 0);
				end--;
				SiftDown(nodes, 0, end, comparer);
			}
			return nodes;
		}
	}
}


