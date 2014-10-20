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
        private const int InitialCapacity = 1000;
        private readonly IDictionary<TId, Node<TData, TId>> nodes;

        /// <remarks>O(1)
        /// Source: http://msdn.microsoft.com/en-us/library/tk84bxf4(v=vs.110).aspx
        /// </remarks>
        public Graph(int initialCapacity = InitialCapacity)
        {
            this.nodes = new Dictionary<TId, Node<TData, TId>>(initialCapacity);
        }

        /// <summary>
        /// Gets the node with the specified Id.
        /// </summary>
        /// <remarks>O(1)
        /// </remarks>
        public Node<TData, TId> this[TId id]
        {
            get
            {
                return nodes.ContainsKey(id) ? nodes[id] : null; // O(1) - Source: http://msdn.microsoft.com/en-us/library/kw5aaea4(v=vs.110).aspx
            }
        }

        /// <remarks>O(1)
        /// </remarks>
        public void AddNode(TData data)
        {
            if (!nodes.ContainsKey(data.Id))
            {
                var node = new Node<TData, TId>(data);
                nodes.Add(node.Id, node);
            }
        }

        /// <remarks>O(1)
        /// </remarks>
        public IEnumerable<Node<TData, TId>> Nodes
        {
            get
            {
                return this.nodes.Values; // O(1) - Source: http://msdn.microsoft.com/en-us/library/ekcfxy3x(v=vs.110).aspx
            }
        }

        /// <remarks>O(1)
        /// </remarks>
        public int NodeCount
        {
            get
            {
                return this.nodes.Count; // O(1) - Source: http://msdn.microsoft.com/en-us/library/zhcy256f(v=vs.110).aspx
            }
        }

        /// <remarks>O(1)
        /// </remarks>
        public int EdgeCount
        {
            get
            {
                return ((this.NodeCount - 1) * this.NodeCount) / 2;
            }
        }
    }
}
