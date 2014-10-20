using System;
using TP1.Graph;

namespace TP1.Influences
{
    public struct Influence<TData, TId>
        where TData : IIdentifiable<TId>
        where TId : IComparable
    {

        public Influence(Node<TData, TId> node, double value)
            : this()
        {
            Node = node;
            Value = value;
        }

        public Node<TData, TId> Node { get; private set; }

        public double Value { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Node.Data.Id, Value);
        }
    }
}
