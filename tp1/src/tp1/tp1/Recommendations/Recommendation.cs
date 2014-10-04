using System;
using TP1.Graph;

namespace tp1.Recommendations
{
    public class Recommendation<TData, TId>
        where TData : IIdentifiable<TId>
        where TId : IComparable
    {
        public Node<TData, TId> Person { get; set; }

        public Node<TData, TId> PersonToRecommend { get; set; }

        public int FriendCount { get; set; }
    }
}
