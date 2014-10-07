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
        public ShortestPath()
        {
            this.Path = new List<Node<TData, TId>>();
        }

        public Node<TData, TId> this[int index]
        {
            get
            {
                return this.Path.ElementAt(index);
            }
        }

        public Node<TData, TId> StartNode { get { return this.Path.First(); } }

        public Node<TData, TId> EndNode { get { return this.Path.Last(); } }

        public int Length
        {
            get { return this.Path.Count; }
        }

        public List<Node<TData, TId>> Path { get; set; }

        public bool PassesThrough(Node<TData, TId> node)
        {
            return this.Path.Contains(node)
                && !this.Path.First().Equals(node)
                && !this.Path.Last().Equals(node);
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
