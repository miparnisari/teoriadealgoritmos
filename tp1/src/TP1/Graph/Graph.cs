using System;
using System.Collections.Generic;

namespace TP1.Graph
{
	/// <summary>
	/// Representation of an undirected graph. 
	/// </summary>
	public class Graph<TData, TId> 
		where TData : IIdentifiable<TId>
		where TId : IComparable
	{
		private readonly IDictionary<TId, Node<TData, TId>> nodes = new Dictionary<TId, Node<TData, TId>>();

		/// <summary>
		/// Gets the <see cref="TP1.Graph.Graph`2"/> with the specified Id.
		/// </summary>
		/// <param name="i">The node Id.</param>
		public Node<TData, TId> this[TId id]
		{
			get
			{
				return nodes.ContainsKey(id) ? nodes[id] : null;
			}
		}

		/// <summary>
		/// Add a new node to the graph.
		/// </summary>
		/// <returns>The added node.</returns>
		/// <param name="data">Data to be added.</param>
		public void AddNode(TData data)
		{
			if (!nodes.ContainsKey(data.Id))
			{
				var node = new Node<TData, TId>(data);
				nodes.Add(node.Id, node);
			}
		}

		/// <summary>
		/// Gets the nodes in the graph in the same order they were added.
		/// </summary>
		/// <value>The nodes.</value>
		public IEnumerable<Node<TData, TId>> Nodes
		{
			get
			{
				return this.nodes.Values;
			}
		}

		/// <summary>
		/// Gets the number of nodes in the graph.
		/// </summary>
		/// <value>number of nodes</value>
		public int Count
		{
			get
			{
				return this.nodes.Count;
			}
		}
	}
}
