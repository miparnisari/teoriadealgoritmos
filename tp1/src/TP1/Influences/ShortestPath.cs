using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP1.Graph;

namespace TP1.Influences
{
    public class ShortestPath<TData, TId>
        where TData : IIdentifiable<TId>
        where TId : IComparable
    {
        /// <remarks>O(1)
        /// Source: http://msdn.microsoft.com/es-AR/library/4kf43ys3(v=vs.110).aspx
        /// </remarks>
        public ShortestPath()
        {
            this.Path = new List<Node<TData, TId>>();
        }

        /// <remarks>O(1)
        /// Source: http://msdn.microsoft.com/en-US/library/0ebtbkkc(v=vs.110).aspx
        /// </remarks>
        public Node<TData, TId> this[int index]
        {
            get
            {
                return this.Path[index];
            }
        }

        /// <remarks>O(1)
        /// </remarks>
        public Node<TData, TId> StartNode { get { return this.Path.First(); } }

        /// <remarks>O(1)
        /// </remarks>
        public Node<TData, TId> EndNode { get { return this.Path.Last(); } }

        /// <remarks>O(1)
        /// Source: http://msdn.microsoft.com/en-US/library/27b47ht3(v=vs.110).aspx
        /// </remarks>
        public int Length
        {
            get { return this.Path.Count; }
        }

        public List<Node<TData, TId>> Path { get; private set; }

        /// <remarks>O(1)
        /// </remarks>
        public bool PassesThrough(Node<TData, TId> node)
        {
            return !this.StartNode.Equals(node)
                && !this.EndNode.Equals(node)
                && this.Path.Contains(node);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < Path.Count - 1; i++)
            {
                stringBuilder.Append(this[i].Id);
                stringBuilder.Append(" - ");
            }
            stringBuilder.Append(this[Path.Count - 1].Id);
            return stringBuilder.ToString();
        }
    }
}
