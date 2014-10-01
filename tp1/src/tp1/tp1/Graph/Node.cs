using System;
using System.Collections.Generic;

namespace TP1.Graph
{
	/// <summary>
	/// Representation of a Graph's node.
	/// </summary>
	public class Node<TData, TId> 
		where TData : IIdentifiable<TId> 
		where TId: IComparable
	{
		private readonly IDictionary<TId, Node<TData, TId>> adjacentNodes = new Dictionary<TId, Node<TData, TId>>();

		/// <summary>
		/// Initializes a new instance of the <see cref="TP1.Graph.Node`2"/> class.
		/// </summary>
		/// <param name="data">Data.</param>
		public Node(TData data)
		{
			Data = data;
		}

		/// <summary>
		/// Gets the data.
		/// </summary>
		/// <value>The data.</value>
		public TData Data
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the Node's identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public TId Id
		{
			get
			{
				return this.Data.Id;
			}
		}

		/// <summary>
		/// Adds the adjacent node to this node.
		/// </summary>
		/// <param name="node">Node.</param>
		public void AddAdjacentNode(Node<TData, TId> node)
		{
			if (!adjacentNodes.ContainsKey(node.Id))
			{
				adjacentNodes.Add(node.Id, node);
			}
		}

		/// <summary>
		/// Gets all adjacent nodes.
		/// </summary>
		/// <value>The adjacents.</value>
		public IEnumerable<Node<TData, TId>> Adjacents
		{
			get
			{
				return this.adjacentNodes.Values;
			}
		}

		/// <summary>
		/// Gets the node degree (i.e. number of edges incident to the vertex)
		/// </summary>
		/// <value>The degree.</value>
		public int Degree
		{
			get
			{
				return adjacentNodes.Values.Count;
			}
		}
	}
}