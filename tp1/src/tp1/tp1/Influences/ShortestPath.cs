using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP1.Graph;

namespace tp1.Influences
{
    public class ShortestPaths<TData, TId>
        where TData : IIdentifiable<TId>
        where TId : IComparable
    {
        public Node<TData, TId> Source { get; set; }

        public Node<TData, TId> Destination { get; set; }

        public IEnumerable<Node<TData, TId>> Paths { get; set; }
    }
}
