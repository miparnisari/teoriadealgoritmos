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
	    private const int InitialCapacity = 1000;
	    private readonly IDictionary<TId, Node<TData, TId>> adjacentNodes;

        /// <remarks>O(1)
        /// </remarks>
	    public Node(int initialCapacity = InitialCapacity)
	    {
            this.adjacentNodes = new Dictionary<TId, Node<TData, TId>>(initialCapacity);
	    }

		public Node(TData data)
            : this()
		{
			Data = data;
		}

		public TData Data
		{
			get;
			private set;
		}

		public TId Id
		{
			get
			{
				return this.Data.Id;
			}
		}

		/// <remarks>O(1)
		/// </remarks>
		public void AddAdjacentNode(Node<TData, TId> node)
		{
            if (!adjacentNodes.ContainsKey(node.Id)) // O(1) - Source: http://msdn.microsoft.com/en-us/library/kw5aaea4(v=vs.110).aspx
			{
                adjacentNodes.Add(node.Id, node); // Best case O(1), worst case O(N) - source: http://msdn.microsoft.com/en-us/library/k7z0zy8k(v=vs.110).aspx
			}
		}

        /// <remarks>O(1)
        /// </remarks>
		public IDictionary<TId, Node<TData, TId>> Adjacents
		{
			get
			{
				return this.adjacentNodes;
			}
		}

		/// <summary>
		/// Gets the node degree (i.e. number of edges incident to the vertex)
		/// </summary>
        /// <remarks>O(1)
        /// </remarks> 
		public int Degree
		{
			get
			{
                return adjacentNodes.Values.Count; // O(1) - source: http://msdn.microsoft.com/en-us/library/6z6y38za(v=vs.110).aspx
			}
		}

	    public override bool Equals(object obj)
	    {
	        var otherNode = obj as Node<TData, TId>;
	        if (otherNode != null)
	        {
	            return this.Id.Equals(otherNode.Id);
	        }
	        return false;
	    }

	    public override int GetHashCode()
	    {
	        return this.Id.GetHashCode();
	    }

	    public override string ToString()
	    {
	        return this.Id.ToString();
	    }
	}
}