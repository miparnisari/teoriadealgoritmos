using System;
using System.Collections.Generic;
using System.Linq;
using TP1.Graph;

namespace TP1.Influences
{
    public class InfluencesCollection<TData, TId>
        where TData : IIdentifiable<TId>
        where TId : IComparable
    {
        private const int InitialCapacity = 1000;

        /// <remarks>O(1)
        /// Source: http://msdn.microsoft.com/es-AR/library/4kf43ys3(v=vs.110).aspx
        /// </remarks>
        public InfluencesCollection(int initialCapacity = InitialCapacity)
        {
            this.Values = new List<Influence<TData, TId>>(initialCapacity);
        }

        public List<Influence<TData, TId>> Values { get; set; }

        /// <remarks>O(1) best case, O(N) worst case
        /// Source: http://msdn.microsoft.com/es-AR/library/3wcytfd1(v=vs.110).aspx
        /// </remarks>
        public void Add(Influence<TData, TId> influence)
        {
            this.Values.Add(influence);
        }

        public IEnumerable<Influence<TData, TId>> OrderByDescending()
        {
            return this.Values.OrderByDescending(i => i.Value);
        }
    }
}
